using System;

namespace Odev39_FlightTicket.Models;

public class FlightTicket
{
    public FlightTicket(string? passengerName, string? flightCode, decimal price)
    {
        PassengerName = passengerName;
        FlightCode = flightCode;
        Price = price;
        SeatClass = "Economy";
    }

    public FlightTicket(string? passengerName, string? flightCode, string? seatClass, decimal price)
    {
        PassengerName = passengerName;
        FlightCode = flightCode;
        SeatClass = seatClass;
        Price = price;
    }

    public string? PassengerName { get; set; }
    public string? FlightCode { get; set; }
    public string? SeatClass { get; set; }
    public decimal Price { get; set; }
}
