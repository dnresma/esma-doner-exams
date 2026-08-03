using Odev08_InventoryItem.Models;

namespace Odev08_InventoryItem;

class Program
{
    static void Main(string[] args)
    {
        InventoryItem inventoryItem = new InventoryItem("Elma");
        Console.WriteLine($"Elmanın başlangıç stoğu: {inventoryItem.Quantity}");
        inventoryItem.IncreaseStok(20);
        inventoryItem.DecreaseStok(30);
        inventoryItem.DecreaseStok(60); //stok yeterli olmadığı için hata fırlatacak

        // Başlangıç stok: 50
        //- 20 artır, 30 azalt, 60 azaltmayı dene (başarısız olmalı)
    }
}
