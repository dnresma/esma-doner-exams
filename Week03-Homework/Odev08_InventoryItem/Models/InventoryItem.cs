using System;

namespace Odev08_InventoryItem.Models;

public class InventoryItem
{
    public InventoryItem(string productName)
    {
        ProductName = productName;
        Quantity = 50;
    }
    private string productName = string.Empty;
    private int quantity;
    public string ProductName 
    { 
        get { return productName;} 
        set { productName = value;} 
    }
    public int Quantity 
    { 
        get { return quantity = 50; } 
        set
        {
            if(quantity < 0)
            {
                throw new ArgumentException("Stok negatif olamaz!");
            }
            quantity = value;
        }
    }
    public void IncreaseStok(int amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Negatif stoklu ürün eklenemez!");
        }
        Quantity += amount;
        Console.WriteLine($"Stoğa {amount} adet ürün eklendi.");
        Console.WriteLine("******************");
    }
    public bool DecreaseStok(int amount)
    {
        if(amount > Quantity)
        {
            throw new ArgumentException($"Stoktan fazla ürün istenemez! Stok: {Quantity}");
        }
        else
        {
            Quantity -=amount;
            Console.WriteLine($"Stoktan {amount} adet ürün azaldı. Kalan stok: {Quantity}");
            Console.WriteLine("******************");
            return true;
        }
    }


}
