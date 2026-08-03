using Odev04_ParkingTicket.Models;

namespace Odev04_ParkingTicket;

class Program
{
    static void Main(string[] args)
    {
        ParkingTicket parkingTicket1 = new ParkingTicket("34EE2004", DateTime.Now);
        parkingTicket1.CalculateFee(100,3);

        ParkingTicket parkingTicket2 = new ParkingTicket("34GUH291", DateTime.Now);
        parkingTicket2.CalculateFee(100,3);

        parkingTicket1.Pay(200);
        parkingTicket2.Pay(100); // Ödeme tutarı yetersiz olduğu için hata fırlatacak.
    }
}
