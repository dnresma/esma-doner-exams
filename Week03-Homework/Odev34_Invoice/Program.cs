using Odev34_Invoice.Models;

namespace Odev34_Invoice;

class Program
{
    static void Main(string[] args)
    {
        Invoice invoice1 = new Invoice(1, "Ekrem", 450);

        Invoice invoice2 = new Invoice(2,"Kemal", 700);

        Invoice[] invoices = {invoice1, invoice2};

        foreach (var invoice in invoices)
        {
            Console.WriteLine($"Müşteri Adı    :{invoice.CustomerName}");
            Console.WriteLine($"Tutarı         :{invoice.Amount} TL");
            Console.WriteLine($"Toplam Tutarı  :{invoice.TotalAmount} TL");
            Console.WriteLine("----------------------------------");
        }
    }
}
