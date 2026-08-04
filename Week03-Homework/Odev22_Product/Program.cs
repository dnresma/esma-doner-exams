using Odev22_Product.Models;

namespace Odev22_Product;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("İpek Elbise");
        product1.Id = 43842;
        product1.Price = 990.99m;
        Product product2 = new Product("Keten Etek");
        product2.Id = 35684;
        product2.Price = 690.99m;
        Product product3 = new Product("Jean");
        product3.Id = 336856;
        product3.Price = 590.99m;

        Console.WriteLine($"Ürün adı: {product1.Name} - Ürün fiyatı: {product1.Price}");
        Console.WriteLine($"Ürün adı: {product2.Name} - Ürün fiyatı: {product2.Price}");
        Console.WriteLine($"Ürün adı: {product3.Name} - Ürün fiyatı: {product3.Price}");
    }
}
