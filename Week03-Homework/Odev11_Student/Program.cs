using Odev11_Student.Models;

namespace Odev11_Student;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student();
        {
            student1.FirstName = "Esma";
            student1.LastName = "Döner";
            student1.StudentNumber = 123456;
            student1.Department = "Computer Engineering";
        }
        Console.WriteLine($"Ad Soyad: {student1.FirstName} {student1.LastName} Öğrenci Numarası: {student1.StudentNumber} Departman: {student1.Department}");

        Student student2 = new Student();
        {
            student2.FirstName = "Emir";
            student2.LastName = "Güngör";
            student2.StudentNumber = 678910;
            student2.Department = "Electrical Engineering";
        }
        Console.WriteLine($"Ad Soyad: {student2.FirstName} {student2.LastName} Öğrenci Numarası: {student2.StudentNumber} Departman: {student2.Department}");
        
    }

}
