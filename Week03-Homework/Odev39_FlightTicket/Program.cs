using Odev39_FlightTicket.Models;

namespace Odev39_FlightTicket;

class Program
{
    static void Main(string[] args)
    {
        FlightTicket ticket1 = new FlightTicket("Elif Tek", "A1332", 5000);

        FlightTicket ticket2 = new FlightTicket("Deniz Aktaş", "F37378", "Business", 12000);

        Console.WriteLine($"{ticket1.PassengerName} - {ticket1.FlightCode} - {ticket1.SeatClass} - {ticket1.Price}");

        Console.WriteLine($"{ticket2.PassengerName} - {ticket2.FlightCode} - {ticket2.SeatClass} - {ticket2.Price}");
    }
}
