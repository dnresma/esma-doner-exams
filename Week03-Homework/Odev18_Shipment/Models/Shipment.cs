using System;

namespace Odev18_Shipment.Models;

public class Shipment
{
    public Shipment(string? teackingNumber, string? senderName, string? receiveName, DateTime shipDate, double weightKg)
    {
        TrackingNumber = teackingNumber;
        SenderName = senderName;
        ReceiverName = receiveName;
        ShipDate = shipDate;
        WeightKg = weightKg;
    }
    public string? TrackingNumber { get; set; }
    public string? SenderName { get; set; }
    public string? ReceiverName { get; set; }
    public DateTime ShipDate { get; set; }
    public double WeightKg { get; set; }
}

