using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShopApp.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signManager;
    private readonly CartRepository _cartRepository;

    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signManager, CartRepository cartRepository)
    {
        _userManager = userManager;
        _signManager = signManager;
        _cartRepository = cartRepository;
    }
    public async Task<(bool Success, string Message)> RegisterAsync(RegisterViewModel model)
    {
        if (await _userManager.FindByEmailAsync(model.Email) is null)
        {
            return (false, "Bu mail adresi zaten kayıtlı.");
        }
        var user = new AppUser
        {
            FullName = model.FullName,
            Email = model.Email,
            UserName = model.Email,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            // result.Errors= [{Description="Hata1", Description="Hata2", Description="Hata3"}]=> "Hata1,Hata2,Hata3"
            return (false, string.Join(",", result.Errors.Select(ie => ie.Description)));
        }
        await _userManager.AddToRoleAsync(user, "Customer");
        await _cartRepository.AddAsync(new Cart { AppUserId = user.Id });
        await _signManager.SignInAsync(user, isPersistent: false);
        return (true, "Kayıt başarılı, hoş geldiniz.");
    }

    public async Task<(bool Success, string Message, bool IsAdmin)> LoginAsync(LoginViewModel model)
    {
        const string failMessage = "Email ya da şifre hatalı.";
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is null) return (true, failMessage, false);
        var result = await _signManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
        if (!result.Succeeded) return (false, failMessage, false);
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        return (true, "Giriş başarılı.", isAdmin);
    }

    public async Task LogoutAsync()
    {
        await _signManager.SignOutAsync();
    }

   public async Task<AccountIndexViewModel?> GetAccountInfoAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return null;

        return new AccountIndexViewModel
        {
            Id = user.Id,
            FullName = user.FullName,
            UserName = user.UserName!,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            EmailConfirmed = user.EmailConfirmed
        };
    }
    public async Task<AccountEditViewModel?> GetAccountForEditAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return null;

        return new AccountEditViewModel
        {
            FullName = user.FullName,
            PhoneNumber = user.PhoneNumber
        };
    }

    public async Task<(bool Success, string Message)> UpdateAccountAsync(string userId, AccountEditViewModel model)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return (false, "Kullanıcı bulunamadı.");

        user.FullName = model.FullName;
        user.PhoneNumber = model.PhoneNumber;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return (false, string.Join(",", result.Errors.Select(e => e.Description)));

        return (true, "Bilgileriniz güncellendi.");
    }

    public async Task<(bool Success, string Message)> ChangePasswordAsync(string userId, ChangePasswordViewModel model)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return (false, "Kullanıcı bulunamadı.");

        var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!result.Succeeded)
            return (false, string.Join(",", result.Errors.Select(e => e.Description)));

        // Şifre değişince güvenlik damgası yenilenir, oturumu tazelemezsek kullanıcının oturumu düşebilir
        await _signManager.RefreshSignInAsync(user);

        return (true, "Şifreniz değiştirildi.");
    }
}
