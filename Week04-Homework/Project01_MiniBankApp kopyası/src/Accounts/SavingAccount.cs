using System;

namespace Project01_MiniBankApp.src.Accounts;

public class SavingAccount : Account
{
    

    public int TermInMonths { get; private set; }
    public DateTime TermDate { get; private set; }
    private const decimal AnnualInterestRate = 0.05m;

    public SavingAccount(string? ownerName, decimal initialBalance, int termInMonths) : base(ownerName, initialBalance)
    {
        TermInMonths = termInMonths;
        TermDate = DateTime.Now.AddMonths(termInMonths);
    }

    public override decimal CalculateInterest()
    {
        decimal termInYears = TermInMonths / 12m;
        return Balance  * AnnualInterestRate * termInYears;
    }

    public override bool CanWithdraw(decimal amount)
    {
        if(amount <= 0)
        {
            Console.WriteLine("Çekilecek tutar negatif olamaz!");
            return false;
        }
        if(amount > Balance)
        {
            Console.WriteLine($"Vadeli Hesap Yetersiz Bakiye! Mevcut Bakiye: {Balance:C2}, Çekilmek İstenen: {amount:C2}");
            return false;
        }
        if(DateTime.Now < TermDate)
            return false;

        return true;
    }
    public override bool Withdraw(decimal amount)
    {
        if (!CanWithdraw(amount))
            return false;

        return base.Withdraw(amount);
    }

    public override string GetAccountType()
    {
        return "Saving Accoount";
    }
}
