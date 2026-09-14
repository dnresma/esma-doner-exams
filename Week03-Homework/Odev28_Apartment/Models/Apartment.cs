using System;

namespace Odev28_Apartment.Models;

public class Apartment
{
    public Apartment(int apartmentNo, int floor)
    {
        ApartmentNo = apartmentNo;
        Floor = floor;
        RoomCount = 2;
    }
    public Apartment(int apartmentNo, int floor, int roomCount)
    {
        ApartmentNo = apartmentNo;
        Floor = floor;
        RoomCount = roomCount;
    }

    public int ApartmentNo { get; set; }    
    public int Floor { get; set; }
    public int RoomCount { get; set; }
    public decimal RentPrice { get; set; }
    
}
