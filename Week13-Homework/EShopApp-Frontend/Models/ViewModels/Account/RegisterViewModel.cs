using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage ="Ad Soyad zorunludur.")]
    [MaxLength(100,ErrorMessage ="Ad Soyad en fazla 100 karakter olabilir.")]
    [Display(Name="Ad Soyad")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage ="Email zorunludur.")]
    [EmailAddress(ErrorMessage ="Geçerli bir email adresi girin.")]
    [Display(Name="Email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage ="Şifre zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name="Şifre")]
    public string Password { get; set; } = string.Empty;


    [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre Tekrarı")]
    [Compare(nameof(Password),ErrorMessage ="Şifreler eşleşmiyor.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
