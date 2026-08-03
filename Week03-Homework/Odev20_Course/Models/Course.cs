using System;

namespace Odev20_Course.Models;

public class Course
{
    public Course(string? courseCode, string? courseName, string? instructor, int credit, bool isOnline)
    {

        CourseCode = courseCode;
        CourseName = courseName;
        Instructor = instructor;
        Credit = credit;
        IsOnline = isOnline;
    }
    public string? CourseCode { get; set; }
    public string? CourseName { get; set; }
    public string? Instructor { get; set; }
    public int Credit { get; set; }
    public bool IsOnline { get; set; }
}
