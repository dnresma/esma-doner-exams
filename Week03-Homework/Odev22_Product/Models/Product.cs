using System;

namespace Odev22_Product.Models;

public class Product
{   
    public Product(string? name)
    {
        Name = name;
    }
    private decimal _price;
    public string? Name { get; set; }
    public int Id { get; set;}    
    public decimal Price 
    { 
        get { return _price; }
        set
        {
            if(_price < 0)
            {
                throw new ArgumentException("Fiyat negatif olamaz!");
            }
            _price = value;
        }
    }
}
