using System;

namespace Odev37_CreditCard.Models;

public class CreditCard
{
    public CreditCard(string? cardHolder, double cardNumber, DateTime expiryDate)
    {
        CardHolder = cardHolder;
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        Limit = 10000;
    }

    public CreditCard(string? cardHolder, double cardNumber, DateTime expiryDate, decimal limit)
    {
        CardHolder = cardHolder;
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        Limit = limit;
    }

    public string? CardHolder { get; set; }
    public double CardNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public decimal Limit { get; set; }
}
