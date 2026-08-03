using Odev03_ShoppingCart.Models;

namespace Odev03_ShoppingCart;

class Program
{
    static void Main(string[] args)
    {
        ShoppingCart shopping1 = new ShoppingCart();
        shopping1.AddItem(100);
        shopping1.AddItem(50.50m); //Hassasiyeti olan noktalı sayılar için m koydum, decimal kullandık
        shopping1.AddItem(255);
        shopping1.ClearCart(); // Sepet boşaltıldı.
        Console.Write($"Sepet tutarı: {shopping1.TotalPrice} Sepet adedi: {shopping1.ItemCount}"); // Sepetin boşaltıldığını doğruladım.

    }
}
