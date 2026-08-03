using System.Reflection.Metadata.Ecma335;
using Odev13_Product.Models;

namespace Odev13_Product;

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product
            {
                ProductCode = 1,
                Name = "Laptop",
                Category = "Electronics",
                UnitPrice = 80000.00m
            },
            new Product
            {
                ProductCode = 2,
                Name = "Smartphone",
                Category = "Electronics",
                UnitPrice = 60000.00m
            },
            new Product
            {
                ProductCode = 3,
                Name = "Refrigerator",
                Category = "Home Appliances",
                UnitPrice = 15000.00m
            },
            new Product
            {
                ProductCode = 4,
                Name = "Washing Machine",
                Category = "Home Appliances",
                UnitPrice = 12000.00m
            }
        };

        foreach (var product in products)
        {
            if (product.Category == "Electronics")
            {
            Console.WriteLine($"Product Code: {product.ProductCode}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Category: {product.Category}");
            Console.WriteLine($"Unit Price: {product.UnitPrice}");
            Console.WriteLine();
            }
        }
    }
}
