using System;

namespace EShopApp.Models.ViewModels.Products;

public class AdminListItemProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
