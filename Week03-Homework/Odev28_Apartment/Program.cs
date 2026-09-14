using Odev28_Apartment.Models;

namespace Odev28_Apartment;

class Program
{
    static void Main(string[] args)
    {
        Apartment apt1 = new Apartment(35,1)
            {
                RentPrice = 25000.00m
            };

            Apartment apt2 = new Apartment(36,2,3)
            {
                RentPrice = 30000.00m
            };

            Apartment[] apartments = { apt1, apt2 };

           
            foreach (Apartment apt in apartments)
            {
                Console.WriteLine($"Daire No   : {apt.ApartmentNo}");
                Console.WriteLine($"Kat        : {apt.Floor}");
                Console.WriteLine($"Oda Sayısı : {apt.RoomCount}");
                Console.WriteLine($"Kira Tutarı: {apt.RentPrice} TL");
                Console.WriteLine("---------------------------------");
            }
    }
}
