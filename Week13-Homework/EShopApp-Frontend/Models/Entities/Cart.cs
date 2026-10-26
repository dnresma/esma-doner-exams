using System;

namespace EShopApp.Models.Entities;

public class Cart
{
    public int Id { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser? AppUser { get; set; }
    public List<CartItem> CartItems { get; set; } = [];
}
