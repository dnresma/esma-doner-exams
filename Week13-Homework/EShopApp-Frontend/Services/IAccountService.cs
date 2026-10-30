using System;
using EShopApp.Models.ViewModels.Account;

namespace EShopApp.Services;

public interface IAccountService
{
    Task<(bool Success, string Message)> RegisterAsync(RegisterViewModel model);
    Task<(bool Success, string Message, bool IsAdmin)> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
    Task<AccountIndexViewModel?> GetAccountInfoAsync(string userId);
    Task<AccountEditViewModel?> GetAccountForEditAsync(string userId);
    Task<(bool Success, string Message)> UpdateAccountAsync(string userId, AccountEditViewModel model);
    Task<(bool Success, string Message)> ChangePasswordAsync(string userId, ChangePasswordViewModel model);
}
