using System;
using System.ComponentModel.DataAnnotations;

namespace EShopApp.Models.ViewModels.Categories;

public class AdminCreateCategoryViewModel
{
    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
    [Display(Name = "Kategori Adı")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Kategori açıklaması en fazla 500 karakter olabilir.")]
    [Display(Name="Açıklama")]
    public string? Description { get; set; }
}
