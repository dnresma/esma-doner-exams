using Odev18_Shipment.Models;

List<Shipment> shipments = new List<Shipment>();
            
Shipment shipment1 = new Shipment ("TR100","Ahmet Yılmaz", "Mehmet Akar", DateTime.Now, 2.5 );
Shipment shipment2 = new Shipment ("TR101", "Selin Al", "Burak Kaya", DateTime.Now, 15.8 );
Shipment shipment3 = new Shipment ("TR102", "Gamze Demir", "Merve Kaymaz", DateTime.Now, 7.2 );

shipments.Add(shipment1);
shipments.Add(shipment2);
shipments.Add(shipment3);

Shipment? maxShipment = null;
double maxWeight = 0;

foreach (Shipment shipment in shipments)
{
    if (shipment.WeightKg > maxWeight)
    {
        maxShipment = shipment;
        maxWeight = shipment.WeightKg;
    }
}

Console.WriteLine($"En Ağır Gönderi Takip No: {maxShipment.TrackingNumber} | Ağırlık: {maxShipment.WeightKg} kg | Gönderici: {maxShipment.SenderName} | Alıcı: {maxShipment.ReceiverName}");

