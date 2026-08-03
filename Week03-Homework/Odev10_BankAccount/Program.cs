using Odev10_BankAccount.Models;

namespace Odev10_BankAccount;

class Program
{
    static void Main(string[] args)
    {
        BankAccount bankAccount = new BankAccount("Esma Döner");
        Console.WriteLine($"Başlangıç bakiyesi: {bankAccount.Balance}");
        bankAccount.Deposit(2500);
        bankAccount.Deposit(7000);
        bankAccount.WithDraw(3000);
        bankAccount.WithDraw(20000);
    }
}
