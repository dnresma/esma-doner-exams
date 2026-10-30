using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Account;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "Mevcut şifre zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mevcut şifre")]
    public string CurrentPassword { get; set; } = null!;

    [Required(ErrorMessage = "Yeni şifre zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Yeni şifre")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
    [Display(Name = "Yeni şifre (tekrar)")]
    public string ConfirmPassword { get; set; } = null!;

}
