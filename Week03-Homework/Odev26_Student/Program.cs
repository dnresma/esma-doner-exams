using Odev26_Student.Models;
namespace Odev26_Constructor_StudentNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Elif", "Deniz")
            {
                Gpa = 3.55
            };

            Student student2 = new Student("Esra", "Engin", 131818)
            {
                Gpa = 3.70
            };

            Student[] students = { student1, student2 };

            foreach (Student student in students)
            {
                if (student.StudentNumber == 0)
                {
                    Console.WriteLine("Numara   : Atanmadı");
                }
                else
                {
                    Console.WriteLine($"Numara   : {student.StudentNumber}");
                }

                Console.WriteLine($"Ad Soyad : {student.FirstName} {student.LastName}");
                Console.WriteLine($"GPA: {student.Gpa}");
                Console.WriteLine("--------------");
                
            }
        }
    }
}
