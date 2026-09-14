using System;

namespace Odev35_Lesson.Models;

public class Lesson
{
    public Lesson(string? lessonCode, string? lessonName, string? ınstructor)
    {
        LessonCode = lessonCode;
        LessonName = lessonName;
        Instructor = ınstructor;
        Credit = 3;
        IsMandatory = Credit > 3;
    }

    public Lesson(string? lessonCode, string? lessonName, string? ınstructor, int credit, bool isMandatory)
    {
        LessonCode = lessonCode;
        LessonName = lessonName;
        Instructor = ınstructor;
        Credit = credit;
        IsMandatory = isMandatory;
    }

    public string? LessonCode { get; set; }
    public string? LessonName { get; set; }
    public string? Instructor { get; set; }
    public int Credit { get; set; }
    public bool IsMandatory { get; set; }
}
