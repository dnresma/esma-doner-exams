using Odev02_Temperature.Models;

namespace Odev02_Temperature;

class Program
{
    static void Main(string[] args)
    {
        Temperature temperature1 = new Temperature(0);
        Console.WriteLine($"Girilen Celsius: {temperature1.Celsius}");
        Console.WriteLine($"Fahrenheit karşılığı: {temperature1.ToFahrenheit()}");
        Console.WriteLine($"Kelvin karşılığı: {temperature1.ToKelvin()}");
        Console.WriteLine("****************************");
        Temperature temperature2 = new Temperature(25);
        Console.WriteLine($"Girilen Celsius: {temperature2.Celsius}");
        Console.WriteLine($"Fahrenheit karşılığı: {temperature2.ToFahrenheit()}");
        Console.WriteLine($"Kelvin karşılığı: {temperature2.ToKelvin}");
        Console.WriteLine("****************************");
        Temperature temperature3 = new Temperature(-40); 
        Console.WriteLine($"Girilen Celsius: {temperature3.Celsius}");
        Console.WriteLine($"Fahrenheit karşılığı: {temperature3.ToFahrenheit()}");
        Console.WriteLine($"Kelvin karşılığı: {temperature3.ToKelvin()}");

        Temperature temperature4 = new Temperature(-280); //Mutlak sıfırı geçtiği için hata fırlatacak
        Console.WriteLine($"Girilen Celsius: {temperature4.Celsius}");
        Console.WriteLine($"Fahrenheit karşılığı: {temperature4.ToFahrenheit()}");
        Console.WriteLine($"Kelvin karşılığı: {temperature4.ToKelvin()}");

    }
}
