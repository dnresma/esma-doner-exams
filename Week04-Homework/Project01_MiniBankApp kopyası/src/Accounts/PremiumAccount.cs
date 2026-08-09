using System;
using System.Security.Cryptography.X509Certificates;
using Project01_MiniBankApp.src.Accounts;

namespace Project01_MiniBankApp.src.Accounts;

public class PremiumAccount : CheckingAccount
{
    

    private const decimal PremiumDailyLimit = 20000m;

    public PremiumAccount(string? ownerName, decimal initialBalance) : base(ownerName, initialBalance)
    {
    }

    public override decimal CalculateInterest()
    {
        return Balance * 0.05m;
    }

    public override bool CanWithdraw(decimal amount)
    {
        if(amount <= 0)
            return false;
        if(amount > Balance)
            return false;
        if(_lastWithdrawDate.Date != DateTime.Now.Date)
        {
            _withdrawnToday = 0;
            _lastWithdrawDate = DateTime.Now;
        }
        if(_withdrawnToday + amount > PremiumDailyLimit)
            return false;
        
        return true;
    }

    public override void RegisterWithdraw(decimal amount)
    {
        if(_lastWithdrawDate.Date != DateTime.Now.Date)
        {
            _withdrawnToday = 0;
            _lastWithdrawDate = DateTime.Now;
        }
        _withdrawnToday += amount;
    }

    public override string GetAccountType()
    {
        return "Premium Account";
    }
}
