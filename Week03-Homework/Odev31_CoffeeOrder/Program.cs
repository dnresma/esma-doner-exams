using Odev31_CoffeeOrder.Models;

namespace Odev31_CoffeeOrder;

class Program
{
    static void Main(string[] args)
    {
        CoffeeOrder order1 = new CoffeeOrder("Esma", "Americano");

        CoffeeOrder order2 = new CoffeeOrder("Ayşe", "Filte Kahve", "large");

        CoffeeOrder order3 = new CoffeeOrder("Zeynwp", "Latte", "small", 1);

        CoffeeOrder[] orders = {order1, order2, order3};

        foreach (var order in orders)
        {
            Console.WriteLine($"Müşteri Adı   : {order.CustomerName}");
            Console.WriteLine($"İçecek Türü   : {order.CoffeeType}");
            Console.WriteLine($"Boyut         : {order.Size}");
            Console.WriteLine($"Şeker Miktarı : {order.SugarCount}");
            Console.WriteLine("------------------------------");
        }
    
    }
}
