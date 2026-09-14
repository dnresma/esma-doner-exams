using System;

namespace Odev32_HotelReservation.Models;

public class HotelReservation
{
    public HotelReservation(string? guestName, int roomNumber, DateTime checkInDate)
    {
        GuestName = guestName;
        RoomNumber = roomNumber;
        CheckInDate = checkInDate;
        NightCount = 1;
    }

    public HotelReservation(string? guestName, int roomNumber, DateTime checkInDate, int nightCount)
    {
        GuestName = guestName;
        RoomNumber = roomNumber;
        CheckInDate = checkInDate;
        NightCount = nightCount;
    }

    public string? GuestName { get; set; }
    public int RoomNumber { get; set; }
    public DateTime CheckInDate { get; set; }
    public int NightCount { get; set; }
    public decimal TotalPrice => NightCount * 1500;
}
