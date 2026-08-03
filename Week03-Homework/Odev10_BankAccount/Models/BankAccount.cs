using System;

namespace Odev10_BankAccount.Models;

public class BankAccount
{
    public BankAccount(string ownerName)
    {
        OwnerName = ownerName;
        Balance = 0;
    }
    private string ownerName = string.Empty;
    private decimal balance;
    public string OwnerName 
    {
        get { return ownerName; } 
        set { ownerName = value; }
    }
    public decimal Balance
    {
        get { return balance; }
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("Bakiye negatif olamaz!");
            }
            balance = value;
        }
    }
    public void Deposit(decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("Yatırılan tutar pozitif olmalı!");
        }
        else
        {
            balance += amount;
            Console.WriteLine($"{amount} TL yatırıldı. Yeni Bakiye: {Balance}");
            Console.WriteLine("*******************");
        }
    }
    public bool WithDraw(decimal amount)
    {
        if(amount <= 0)
        {
            throw new ArgumentException("Çekilecek tutar pozitif olmalı!");
        }
        if(amount > Balance)
        {
            Console.WriteLine($"Yetersiz Bakiye! İstenen: {amount} TL \nBakiye: {Balance}");
            Console.WriteLine("*******************");
            return false;
        }
        Balance -= amount;
        Console.WriteLine($"{amount} TL çekildi. Yeni Bakiye: {Balance}");
        Console.WriteLine("*******************");
        return true;
    }


}
