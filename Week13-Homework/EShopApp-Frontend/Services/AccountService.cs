using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace EShopApp.Services;

public class AccountService
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
}
