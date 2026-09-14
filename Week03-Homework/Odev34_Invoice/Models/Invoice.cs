using System;

namespace Odev34_Invoice.Models;

public class Invoice
{
    public Invoice(int ınvoiceNo, string? customerName, decimal amount)
    {
        InvoiceNo = ınvoiceNo;
        CustomerName = customerName;
        Amount = amount;
        TextRate = 0.20m;
    }

    public Invoice(int ınvoiceNo, string? customerName, decimal amount, decimal textRate)
    {
        InvoiceNo = ınvoiceNo;
        CustomerName = customerName;
        Amount = amount;
        TextRate = textRate;
    }

    public int InvoiceNo { get; set; }
    public string? CustomerName { get; set; }
    public decimal Amount { get; set; }
    public decimal TextRate { get; set; }
    public decimal TotalAmount => (Amount * TextRate) + Amount;

}
