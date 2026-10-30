using System;

namespace EShopApp.Models.ViewModels.Account;

public class AccountIndexViewModel
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
}
