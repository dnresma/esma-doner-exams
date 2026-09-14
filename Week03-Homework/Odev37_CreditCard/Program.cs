using Odev37_CreditCard.Models;

namespace Odev37_CreditCard;

class Program
{
    static void Main(string[] args)
    {
        CreditCard creditcard1 = new CreditCard("Ekin Koç", 3957285529, DateTime.Now.AddYears(10));

        CreditCard creditcard2 = new CreditCard("Eda Ece", 3836809536, DateTime.Now.AddYears(10), 50000);

        CreditCard[] creditcards = {creditcard1, creditcard2};

        foreach (var crd in creditcards)
        {
            Console.WriteLine($"Kart Sahibi: {crd.CardHolder}");
            Console.WriteLine($"Limit: {crd.Limit}");
            Console.WriteLine($"Son Kullanma Tarihi: {crd.ExpiryDate}");
            Console.WriteLine("***********************************");
        }
    }
}
