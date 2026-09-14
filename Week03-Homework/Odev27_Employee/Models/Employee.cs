using System;

namespace Odev27_Employee.Models;

public class Employee
{
    public Employee(string? fullName)
    {
        FullName = fullName;
        Position = "Junior";
    }
    public Employee(string? fullName, string? position)
    {
        FullName = fullName;
        Position = position;
    }

    public int EmployeeId { get; set; }
    public string? FullName { get; set; }
    public string? Position { get; set; }
    public decimal Salary { get; set; }
}
