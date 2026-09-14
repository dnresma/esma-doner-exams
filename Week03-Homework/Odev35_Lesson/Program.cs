using Odev35_Lesson.Models;

namespace Odev35_Lesson;

class Program
{
    static void Main(string[] args)
    {
        Lesson less1 = new Lesson("Math101", "Genel Matematik", "Ali Çetin");

        Lesson less2 = new Lesson("Fiz101", "Genel Fizik", "Filiz Akın", 5, true);

        Console.WriteLine($"{less1.LessonCode} - {less1.LessonName} - {less1.Credit} - {less1.IsMandatory}");

        Console.WriteLine("---------------------------");

        Console.WriteLine($"{less2.LessonCode} - {less2.LessonName} - {less2.Credit} - {less2.IsMandatory}");
        Console.WriteLine("***************************");
        Console.WriteLine($"Total kredi: {less1.Credit + less2.Credit}");
    }
}
