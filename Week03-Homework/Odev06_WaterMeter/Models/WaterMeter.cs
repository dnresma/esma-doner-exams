using System;

namespace Odev06_WaterMeter.Models;

public class WaterMeter
{
    public WaterMeter(string meterNumber, int currentReading)
    {
        MeterNumber = meterNumber; //5 haneli olsun
        CurrentReading = currentReading;
    }
    private string meterNumber = string.Empty;
    private int currentReading;
    public string MeterNumber 
    { 
        get { return meterNumber; } 
        set 
        {
            if (value.Length !=5)
            {
                throw new ArgumentException("Sayaç numarası 5 haneli olmalıdır.");
            }
            meterNumber = value;

        } 
    }
    public int CurrentReading 
    { 
        get { return currentReading; } 
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Sayaç değeri negatif olamaz!");
            }  
            currentReading = value;
            
            
        } 
    }

    public void RecordReading(int newReading)
    {
        if(newReading < CurrentReading)
        {
            throw new ArgumentException("Yeni sayaç okuması eski değerden düşük olamaz!");
        }
        CurrentReading = newReading;
        Console.WriteLine($"Sayaç güncellendi. {MeterNumber} numaralı sayacın yeni değeri: {CurrentReading}");
            
    }

    public int CalculateConsumption(int previousReading)
    {
        if(CurrentReading < previousReading)
        {
          throw new ArgumentException("Yeni sayaç okuması eski değerden düşük olamaz!");  
        }
        Console.WriteLine($"Ödenmesi gereken miktar: {CurrentReading - previousReading}");
        return CurrentReading - previousReading;
        
        
    }
}
