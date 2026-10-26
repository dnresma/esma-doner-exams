using System;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Products;

namespace EShopApp.Models.ViewModels.Categories;

public class DetailsCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ProductImageUrl { get; set; } = string.Empty;    
    public string ProductName { get; set; } = string.Empty;    
    public decimal ProductPrice { get; set; } 
    public int ProductStock { get; set; }
    public List<DetailsProductViewModel> Products { get; set; } = [];
}
