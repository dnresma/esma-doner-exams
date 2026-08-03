using Odev15_Car.Models;

namespace Odev15_Car;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car
            {
                Brand = "Renault",
                Model = "Clio",
                Year = 2022,
                PlateNumber = "34 GUH 291",
                Color = "White"
            },
            new Car
            {
                Brand = "Wolkswagen",
                Model = "Passat",
                Year = 2019,
                PlateNumber = "34 CEP 331",
                Color = "Black"
            },
            new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                PlateNumber = "34 GJH 295",
                Color = "Red"
            }
        };

        Console.WriteLine("Arabalar:");
        Console.WriteLine("******************");
        foreach (var car in cars)
        {
            Console.WriteLine($"Marka: {car.Brand}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Yıl: {car.Year}");
            Console.WriteLine($"Plaka: {car.PlateNumber}");
            Console.WriteLine($"Renk: {car.Color}");
            Console.WriteLine();
        }
    }
}
    