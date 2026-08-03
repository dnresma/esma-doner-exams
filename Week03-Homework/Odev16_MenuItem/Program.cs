namespace Odev16_MenuItem.Models;

class Program
{
    static void Main(string[] args)
    {
        List<MenuItem> menuItems = new List<MenuItem>();
        MenuItem menuItem1 = new MenuItem("Süper Pizza", "el yapımı dometes sos, yeşil zeytin, salam, sosis, mozarella", 350.00m, false);
        MenuItem menuItem2 = new MenuItem("Vejetaryen Pizza", "el yapımı dometes sos, yeşil zeytin, mantar, mozarella", 300.00m, true);
        MenuItem menuItem3 = new MenuItem("Vejeteryan Hamburger", "el yapımı taze ekmek, domates, kıvırcık, vegan köfte", 250.00m, true);
        MenuItem menuItem4 = new MenuItem("Klasik Hamburger", "el yapımı taze ekmek, domates, kıvırcık, dana köfte", 300.00m, false);
        MenuItem menuItem5 = new MenuItem("Vejetaryen Dürüm", "el yapımı lavaş, domates, kıvırcık, vegan köfte", 200.00m, true);

        menuItems.Add(menuItem1);
        menuItems.Add(menuItem2);
        menuItems.Add(menuItem3);
        menuItems.Add(menuItem4);
        menuItems.Add(menuItem5);

        foreach (MenuItem item in menuItems)
        {
            if (item?.Name?.Contains("Vejetaryen") == true)
            {
                Console.WriteLine($"{item.Name} - {item.Description} - {item.Price:C}");
            }
        }
    }
}
