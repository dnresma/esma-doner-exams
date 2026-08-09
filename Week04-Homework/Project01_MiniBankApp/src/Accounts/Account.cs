using System;
using System.Diagnostics.Contracts;

namespace Project01_MiniBankApp.src.Accounts;

public abstract class Account
{
    protected Account(string? ownerName, decimal initialBalance)
    {
        
        AccountId = Guid.NewGuid();
        OwnerName = ownerName;
        _balance = initialBalance;
        IsActive = true;
        CreateAt = DateTime.Now;
    }

    public Guid AccountId { get; private set; }
    public string? OwnerName { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreateAt { get; private set; }
    private decimal _balance;
    public decimal Balance => _balance;
    public virtual void Deposit(decimal amount)
    {
        if(!IsActive)
            throw new ArgumentException("Hesap kapalı para yatırılamaz!");
        if(amount <= 0)
            throw new ArgumentException("Yatırılacak tutar 0'dan büyük olmalıdır!");
        _balance += amount;
    }
    public virtual bool Withdraw(decimal amount)
    {
        if(!IsActive)
            throw new ArgumentException("Hesap kapalı para çekilemez!");
        if(amount <=0 )
            throw new ArgumentException("Çekilecek tutar 0'dan büyük olmalıdır!");
        if(!CanWithdraw(amount))
        {
            return false;
        }
        _balance -= amount;
        return true;
    }
    public void Close()
    {
        IsActive = false;
    }
    public abstract bool CanWithdraw(decimal amount);
    public abstract decimal CalculateInterest();
    public abstract string GetAccountType();
       
}

