using System;
using EShopApp.Models.Enums;

namespace EShopApp.Models.ViewModels.Orders;

public class OrdersIndexViewModel
{
    public OrdersIndexViewModel(List<ListItemOrderViewModel> orders, List<OrderStatus> orderStatuses, OrderStatus? selectedOrderStatus)
    {
        Orders = orders;
        OrderStatuses = orderStatuses;
        SelectedOrderStatus = selectedOrderStatus;
    }

    public List<ListItemOrderViewModel> Orders { get; set; } = [];
    public List<OrderStatus> OrderStatuses { get; set; } = [];
    public OrderStatus? SelectedOrderStatus { get; set; }
}
