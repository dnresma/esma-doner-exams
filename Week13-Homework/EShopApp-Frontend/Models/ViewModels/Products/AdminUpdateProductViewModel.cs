using System;
using System.ComponentModel.DataAnnotations;
using EShopApp.Models.ViewModels.Categories;

namespace EShopApp.Models.ViewModels.Products;

public class AdminUpdateProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ürün adı zorunludur.")]
    [MaxLength(150, ErrorMessage = "Ürün adı en fazla 150 karakter olabilir.")]
    [Display(Name = "Ürün Adı")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ürün açıklaması zorunludur.")]
    [MaxLength(1000, ErrorMessage = "Ürün adı en fazla 1000 karakter olabilir.")]
    [Display(Name = "Ürün Açıklaması")]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük bir değer olmalıdır")]
    [Display(Name = "Fiyat")]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz")]
    [Display(Name="Stok Miktarı")]
    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Geçeriz kategori.")]
    [Display(Name = "Kategori")]
    public int CategoryId { get; set; }

    [Display(Name="Kategori")]
    public List<ListItemCategoryViewModel> Categories { get; set; } = [];
}
