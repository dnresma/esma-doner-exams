using Odev32_HotelReservation.Models;

namespace Odev32_HotelReservation;

class Program
{
    static void Main(string[] args)
    {
        HotelReservation rez1 = new HotelReservation("Elif Kaya", 11, DateTime.Now);

        HotelReservation rez2 = new HotelReservation("Vedat Tekin", 15, DateTime.Now, 4);

        HotelReservation[] rezervations = {rez1, rez2};

        foreach (var rez in rezervations)
        {
            Console.WriteLine($"Müşteri Adı  : {rez.GuestName}");
            Console.WriteLine($"Oda No       : {rez.RoomNumber}");
            Console.WriteLine($"Giriş Tarihi : {rez.CheckInDate.ToShortDateString()}");
            Console.WriteLine($"Gece Sayısı  : {rez.NightCount}");
            Console.WriteLine($"Toplam Tutar : {rez.TotalPrice} TL");
            Console.WriteLine("-----------------"); 
        }
    }
}
