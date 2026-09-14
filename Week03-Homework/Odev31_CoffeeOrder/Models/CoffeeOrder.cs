using System;

namespace Odev31_CoffeeOrder.Models;

public class CoffeeOrder
{
    public CoffeeOrder(string? customerName, string? coffeeType)
    {
        CustomerName = customerName;
        CoffeeType = coffeeType;
        Size = "Medium";
        SugarCount = 0;
    }

    public CoffeeOrder(string? customerName, string? coffeeType, string? size)
    {
        CustomerName = customerName;
        CoffeeType = coffeeType;
        Size = size;
        SugarCount = 0;
    }

    public CoffeeOrder(string? customerName, string? coffeeType, string? size, int sugarCount)
    {
        CustomerName = customerName;
        CoffeeType = coffeeType;
        Size = size;
        SugarCount = sugarCount;
    }

    public string? CustomerName { get; set; }
    public string? CoffeeType { get; set; }
    public string? Size { get; set; }
    public int SugarCount { get; set; }
}
