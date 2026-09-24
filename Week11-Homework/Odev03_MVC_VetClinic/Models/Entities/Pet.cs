using System;

namespace Odev03_MVC_VetClinic.Models.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Species { get; set; } = null!;
    public int Age { get; set; }
}
