using Odev21_BankAccount.Models;

namespace Odev21_BankAccount;

class Program
{
    static void Main(string[] args)
    {
        BankAccount customer1 = new BankAccount("Esma Döner");
        BankAccount customer2 = new BankAccount("Emir Güngör", 50000);

        Console.WriteLine($"Hesap sahibi: {customer1.OwnerName} | Bakiye: {customer1.Balance}");
        Console.WriteLine($"Hesap sahibi: {customer2.OwnerName} | Bakiye: {customer2.Balance}");
    }
}
