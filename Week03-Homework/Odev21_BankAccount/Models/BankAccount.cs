using System;

namespace Odev21_BankAccount.Models;

public class BankAccount
{
    public BankAccount(string? ownerName)
    {
        OwnerName = ownerName;
        Balance = _balance;
    }
    public BankAccount(string? ownerName, decimal balance)
    {
        OwnerName = ownerName;
        Balance = balance;
    }
    private decimal _balance = 0;
    public string? OwnerName { get; set; }
    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            if(Balance < 0)
            {
                throw new ArgumentException("Bakiye negatif olamaz!");
            }
            _balance = value;
            
        }
    }
    

    
}
