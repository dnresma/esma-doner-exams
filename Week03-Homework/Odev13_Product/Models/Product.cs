using System;

namespace Odev13_Product.Models;

public class Product
{
    public int ProductCode { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
}
