using System;
using EShopApp.Models.Enums;

namespace EShopApp.Models.ViewModels.Orders;

public class AdminOrdersIndexViewModel
{
    public List<ListItemOrderViewModel> Orders { get; set; } = [];
    public OrderStatus? SelectedStatus { get; set; }
    public Dictionary<OrderStatus, int> StatusCounts { get; set; } = [];
}
