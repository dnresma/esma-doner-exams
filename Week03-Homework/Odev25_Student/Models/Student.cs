using System;

namespace Odev25_Student.Models;

public class Student
{
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public string StudentNumber { get; set; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; } = string.Empty;

}
