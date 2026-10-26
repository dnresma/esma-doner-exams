using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Orders;

public class CreateOrderViewModel
{
    [Required(ErrorMessage = "Teslimat adersi zorunludur.")]
    [MaxLength(500, ErrorMessage = "Teslimat adresi en fazla 500 karakter olabilir")]
    [Display(Name = "Teslimat Adresi")]
    public string ShippingAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon numarası zorunludur.")]
    [RegularExpression(@"^0\d{3} \d{3} \d{2} \d{2}$", ErrorMessage = "Geçerli bir telefon numarası girin.")]
    [Display(Name = "Telefon")]
    public string PhoneNumber { get; set; } = string.Empty;


}
