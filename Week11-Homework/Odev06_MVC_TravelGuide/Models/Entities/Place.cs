using System;

namespace Odev06_MVC_TravelGuide.Models.Entities;

public class Place
{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public int EntryFee { get; set; }
}
