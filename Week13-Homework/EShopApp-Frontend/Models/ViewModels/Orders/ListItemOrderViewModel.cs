using System;
using EShopApp.Models.Enums;

namespace EShopApp.Models.ViewModels.Orders;

public class ListItemOrderViewModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public int ItemCount { get; set; }
    public decimal Total { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
}
