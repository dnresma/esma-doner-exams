using Odev06_WaterMeter.Models;

namespace Odev06_WaterMeter;

class Program
{
    static void Main(string[] args)
    {
        WaterMeter waterMeter1 = new WaterMeter("56684",1000);
        Console.WriteLine($"{waterMeter1.MeterNumber} numaralı sayacın başlangıç değeri: {waterMeter1.CurrentReading}");
        waterMeter1.RecordReading(1250);
        waterMeter1.CalculateConsumption(1000);
    }
}
