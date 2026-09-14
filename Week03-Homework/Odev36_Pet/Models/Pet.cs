using System;

namespace Odev36_Pet.Models;

public class Pet
{
    public Pet(string? name, string? ownerName)
    {
        Name = name;
        Type = "Unknown";
        OwnerName = ownerName;
    }

    public Pet(string? name, string? type, int age, string? ownerName)
    {
        Name = name;
        Type = type;
        Age = age;
        OwnerName = ownerName;
    }

    public string? Name { get; set; }
    public string? Type { get; set; }
    public int Age { get; set; }
    public string? OwnerName { get; set; }
}
