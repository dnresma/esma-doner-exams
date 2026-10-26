using System;

namespace EShopApp.Models.ViewModels.Carts;

public class CartViewModel
{
    public List<CartItemViewModel> Items { get; set; } = [];
    public decimal Total => Items.Sum(i=>i.LineTotal);
    public int ItemCount => Items.Sum(i=>i.Quantity);
}
