using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Account;

public class AccountEditViewModel
{
    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    [StringLength(100, ErrorMessage = "Ad soyad en fazla 100 karakter olabilir.")]
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; } = null!;

    [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
    [Display(Name = "Telefon")]
    public string? PhoneNumber { get; set; }
}
