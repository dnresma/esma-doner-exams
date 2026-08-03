using System;

namespace Odev02_Temperature.Models;

public class Temperature
{
    public Temperature(double celsius)
    {
        Celsius = celsius;
    }
    private double celsius;
    public double Celsius 
    { 
        get { return celsius;} 
        set
        {
            if(value < -273.15)
            {
                throw new ArgumentException($"{value} mutlak sıfırın (-273.15) altında olamaz");
            }
            else
            {
                celsius = value;
            } 
        }
    }
    public double ToFahrenheit()
    {
        return (celsius * 9/5) + 32;
    }
    public double ToKelvin()
    {
        return (celsius + 273.15);
    }
}
