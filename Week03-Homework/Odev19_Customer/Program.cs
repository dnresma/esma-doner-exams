using System.Runtime.Serialization;
using Odev19_Customer.Models;

namespace Odev19_Customer;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Esma Döner", "Akat Mah. No:25 Sarıyer/İstanbul", new DateTime(2004, 11, 3));
        Customer customer2 = new Customer("Ela Durmaz", "Çelik Sok. No:45 Beşiktaş/İstanbul", new DateTime(1990,12,21));

        Console.WriteLine("Müşteri Bilgileri:");
        Console.WriteLine($"Ad Soyad: {customer1.Name} | Adres: {customer1.Address} | Doğum Tarihi: {customer1.BirthDate}");
        Console.WriteLine($"Ad Soyad: {customer2.Name} | Adres: {customer2.Address} | Doğum Tarihi: {customer2.BirthDate}");
    }
}
