using System;

namespace Odev05_MVC_CafeMenu.Models.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } =null!;
    public string Category { get; set; } = null!;
    public int Price { get; set; }
}
