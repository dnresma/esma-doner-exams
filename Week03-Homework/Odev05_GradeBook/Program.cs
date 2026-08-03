using Odev05_GradeBook.Models;

namespace Odev05_GradeBook;

class Program
{
    static void Main(string[] args)
    {
        GradeBook gradeBook1 = new GradeBook("Esma Döner");
        gradeBook1.AddExamScore(85);
        gradeBook1.AddExamScore(80);
        gradeBook1.AddExamScore(90);
        gradeBook1.AddExamScore(95);
        gradeBook1.AddExamScore(105); //Hata fırlatacak çünkü doğru aralıkta değil
        gradeBook1.GetAverage(85,80,90,95);

        try
        {
            gradeBook1.AddExamScore(105);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
        
    }
}
