namespace Odev25_Student.Models;

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Ali", "Yılmaz");
        student1.StudentNumber = "101";
        student1.Department = "Yazılım Mühendisliği";

        Student student2 = new Student("Zeynep", "Demir");
        student2.StudentNumber = "102";
        student2.Department = "Bilgisayar Programcılığı";

        Console.WriteLine($"1. Öğrenci adı: {student1.FirstName} {student1.LastName} | No: {student1.StudentNumber} | Bölüm: {student1.Department}");
        Console.WriteLine($"2. Öğrenci adı: {student2.FirstName} {student2.LastName} | No: {student2.StudentNumber} | Bölüm: {student2.Department}");
    }
}
