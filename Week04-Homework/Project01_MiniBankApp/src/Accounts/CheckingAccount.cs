using System;

namespace Project01_MiniBankApp.src.Accounts;

public class CheckingAccount : Account 
{
        

    private protected const decimal DailyWithdrawLimit = 10000m;
    private protected decimal _withdrawnToday = 0m;
    private protected DateTime _lastWithdrawDate = DateTime.MinValue;

    public CheckingAccount(string? ownerName, decimal initialBalance) : base(ownerName, initialBalance)
    {
    }

    public override decimal CalculateInterest()
    {
        return Balance * 0.02m;
    }

    public override bool CanWithdraw(decimal amount)
    {
        if(amount <= 0)
            return false;
        if(amount > Balance)
        {
            Console.WriteLine($"[UYARI] Yetersiz bakiye! Mevcut Bakiye: {Balance:C2}, Çekilmek İstenen: {amount:C2}");
            return false;
        } 
        if(_lastWithdrawDate.Date != DateTime.Now.Date)
        {
            _withdrawnToday = 0;
    
        }
        if(_withdrawnToday + amount > DailyWithdrawLimit)
        {
            decimal remainLimit = DailyWithdrawLimit - _withdrawnToday;
            throw new ArgumentException($"[UYARI] Günlük para çekme limiti aşıldı! " +
                              $"Günlük Limit: {DailyWithdrawLimit:C2}, Bugünkü Çekiminiz: {_withdrawnToday:C2}, " +
                              $"Kalan Çekim Hakkınız: {(remainLimit < 0 ? 0 : remainLimit):C2}");
        
        }
        
        return true;
    }
    public override bool Withdraw(decimal amount)
    {
        if(!CanWithdraw(amount))
            return false;
        bool success = base.Withdraw(amount);
        if(success)
        {
            _lastWithdrawDate = DateTime.Now;
            _withdrawnToday += amount;
        }
        return success;
    }

    public virtual void RegisterWithdraw(decimal amount)
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
        return "Checking Account";
    }
}
