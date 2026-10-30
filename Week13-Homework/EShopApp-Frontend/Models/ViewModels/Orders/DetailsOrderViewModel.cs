using System;
using EShopApp.Models.Enums;

namespace EShopApp.Models.ViewModels.Orders;

public class DetailsOrderViewModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public List<OrderLineViewModel> Lines { get; set; } = [];
    public decimal Total => Lines.Sum(l => l.LineTotal);
    public bool CanCancel => Status == OrderStatus.Pending;
    public List<OrderStatus> NextStatuses { get; set; } = [];
    public string CurrentStatus { get; set; }
}