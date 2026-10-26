using System;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Carts;

namespace EShopApp.Models.ViewModels.Orders;

public class CheckoutViewModel:CreateOrderViewModel
{
    public CartViewModel Cart { get; set; } = new();
}
