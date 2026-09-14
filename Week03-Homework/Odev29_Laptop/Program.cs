using Odev29_Laptop.Models;

namespace Odev29_Laptop;

class Program
{
    static void Main(string[] args)
    {
        
        Laptop laptop1 = new Laptop("Lenova", "IdeaBook4");
        laptop1.RamGb = 8;         
        laptop1.StorageGb = 256;   
        laptop1.Price = 40000;
            
        Laptop laptop2 = new Laptop("Apple", "MacBook Air", 16, 256);
        laptop2.Price = 70000;

        Laptop[] laptops = { laptop1, laptop2 };

        foreach (Laptop laptop in laptops)
        {
            Console.WriteLine($"Marka    : {laptop.Brand}");
            Console.WriteLine($"Model    : {laptop.Model}");
            Console.WriteLine($"RAM      : {laptop.RamGb} GB");
            Console.WriteLine($"Depolama : {laptop.StorageGb} GB");
            Console.WriteLine($"Fiyat    : {laptop.Price} TL");
            Console.WriteLine("--------------------------------");
        }
    }
}
