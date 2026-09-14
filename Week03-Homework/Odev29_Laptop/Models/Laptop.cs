using System;

namespace Odev29_Laptop.Models;

public class Laptop
{
    public Laptop(string? brand, string? model)
    {
        Brand = brand;
        Model = model;
    }
    public Laptop(string? brand, string? model, int ramGb, int storageGb)
    {
        Brand = brand;
        Model = model;
        RamGb = ramGb;
        StorageGb = storageGb;
    }

    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int RamGb { get; set; }
    public int StorageGb { get; set; }
    public decimal Price { get; set; }
}
