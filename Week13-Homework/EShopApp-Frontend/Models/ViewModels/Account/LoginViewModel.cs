using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage ="Email zorunludur.")]
    [EmailAddress(ErrorMessage ="Geçerli bir email adresi girin.")]
    [Display(Name="Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Şifre zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name="Şifre")]
    public string Password { get; set; } = string.Empty;

    [Display(Name="Beni hatırla")]
    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}
