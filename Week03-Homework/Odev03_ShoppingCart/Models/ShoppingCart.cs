using System;

namespace Odev03_ShoppingCart.Models;

public class ShoppingCart
{
    public ShoppingCart()
    {
        ItemCount = 0;
        TotalPrice = 0;
    }
    private int itemCount;
    public int ItemCount
    {
        get { return itemCount; }
        private set
        {
            if(value < 0)
                itemCount = 0;
            else
                itemCount = value;  
        }
    }
    private decimal totalPrice;
    public decimal TotalPrice 
    { 
        get { return totalPrice; } 
        set
        {
            if(value < 0)
                totalPrice = 0;
            else 
                totalPrice = value;
        } 
    }

    public void AddItem (decimal price)
    {
        if(price < 0)
        {
            throw new ArgumentException("Ürün fiyatı negatif olamaz.");
        }
        else
        {
            ItemCount++;
            TotalPrice += price;
            Console.WriteLine($"Sepete {price} TL tutarında ürün eklendi. Toplam ürün adedi: {itemCount}");
        }
    }
    public void ClearCart()
    {
        ItemCount = 0;
        TotalPrice = 0;
        Console.WriteLine("Sepet boşaltıldı.");
    }
    
}
