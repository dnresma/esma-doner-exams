using System;

namespace Odev04_ParkingTicket.Models;

public class ParkingTicket
{
    public ParkingTicket(string plateNumber, DateTime entryTime)
    {
        PlateNumber = plateNumber;
        EntryTime = entryTime;
        IsPaid = false; //Bilet ilk oluştuğunda ödenmedi
    }
    private string plateNumber = string.Empty;
    private DateTime entrytime;
    private bool ispaid;
    private decimal calculateFee;
    public string PlateNumber {
        get { return plateNumber; }
        set { plateNumber = value; }
    }
    public DateTime EntryTime 
    { 
        get {return entrytime; }
        set {entrytime = value; }
    }
    public bool IsPaid 
    { 
        get { return ispaid; } 
        set { ispaid = value; }
    }
    
    public decimal CalculateFee(decimal hourlyRate, int hours)
    {
        if(hourlyRate <= 0 || hours <=0)
        {
            throw new ArgumentException("Saat veya saatlik ücret sıfırdan büyük olmalıdır.");
        }
        else
        {
            calculateFee = hourlyRate * (hours - 1); //ilk bir saat ücretsiz
            Console.WriteLine($"{PlateNumber} plakalı araç sahibi ödemeniz gereken tutar {calculateFee} TL");
            Console.WriteLine("******************");
            return calculateFee;

        }
    }

    public bool Pay(decimal amount)
    {
        if(amount >= calculateFee)
        {
            IsPaid = true;
            Console.WriteLine($"{plateNumber} plakalı araç sahibi ödemeniz paşarıyla tamamlanmıştır.");
            Console.WriteLine("******************");
            return true;
        }
        else
        {
            throw new ArgumentException($"Ödemeniz gerçekleşmedi. Yatırmanız gereken tutar: {calculateFee}");
            
        }
    }
}
