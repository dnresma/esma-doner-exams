using System;

namespace Odev11_Student.Models;

public class Student
{
    public Student()
    {
        FirstName = "";
        LastName = "";
        StudentNumber = 0;
        Department = "";
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentNumber { get; set; }
    public string Department { get; set; }
    
}
