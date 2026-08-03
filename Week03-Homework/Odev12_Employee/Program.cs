using Odev12_Employee.Models;

namespace Odev12_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee { FullName = "Esra Döner", Title = "Uzman", Department = "Yazılım", HireDate = DateTime.Now.AddYears(-2) };
            Employee e2 = new Employee { FullName = "Esma Döner", Title = "Yazılım Geliştirici", Department = "Bilgi Teknolojileri", HireDate = DateTime.Now.AddYears(-1) };
            Employee e3 = new Employee { FullName = "Gülşah Döner", Title = "Müdür", Department = "Pazarlama", HireDate = DateTime.Now.AddYears(-5) };

            Employee[] employees = { e1, e2, e3 };

            foreach (var employee in employees)
            {
                Console.WriteLine($"Çalışan: {employee.FullName} | Unvan: {employee.Title} | Departman: {employee.Department}");
            }
        }
    }
}