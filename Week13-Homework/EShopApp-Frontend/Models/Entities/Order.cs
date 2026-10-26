using System;
using EShopApp.Models.Enums;

namespace EShopApp.Models.Entities;

public class Order
{
    public int Id { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser? AppUser { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public string ShippingAddress { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
