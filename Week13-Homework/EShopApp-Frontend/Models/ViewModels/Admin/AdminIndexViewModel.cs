using System;
using EShopApp.Models.ViewModels.Categories;
using EShopApp.Models.ViewModels.Orders;
using EShopApp.Models.ViewModels.Products;

namespace EShopApp.Models.ViewModels.Admin;

public class AdminIndexViewModel
{
    public int TotalProducts { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalSales { get; set; }

}
