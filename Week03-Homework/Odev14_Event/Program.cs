using Odev14_Event.Models;

List<Event> events = new List<Event>
        {
            new Event
            {
                Title = "Yaza Merhaba Partisi",
                Location = "Beach Club",
                EventDate = DateTime.Now.AddDays(7),
                Capacity = 200
            },
            new Event
            {
                Title = "Yılbaşı Kutlaması",
                Location = "Merkez Salon",
                EventDate = DateTime.Now.AddDays(14),
                Capacity = 100
            }
        };
Console.WriteLine("Gelecek Etkinlikler:");
Console.WriteLine("--------------------");
foreach (var e in events)
{
    Console.WriteLine($"Title: {e.Title}");
    Console.WriteLine($"Location: {e.Location}");
    Console.WriteLine($"Date: {e.EventDate}");
    Console.WriteLine($"Capacity: {e.Capacity}");
    Console.WriteLine();
}
