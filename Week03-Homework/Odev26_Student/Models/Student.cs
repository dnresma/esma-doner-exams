using System;

namespace Odev26_Student.Models;

public class Student
{
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        StudentNumber = 0; //Henüz numara tanımlanmamış öğrenciler
    }
    public Student(string firstName, string lastName, int studentNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        StudentNumber = studentNumber;
    }
    public int StudentNumber { get; set; } 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public double Gpa { get; set; }
}
