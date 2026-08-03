using System;

namespace Odev19_Customer.Models;

public class Customer
{
    public Customer(string? name, string? address, DateTime birthDate)
    {
        Name = name;
        Address = address;
        BirthDate = birthDate;
    }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }  
}
