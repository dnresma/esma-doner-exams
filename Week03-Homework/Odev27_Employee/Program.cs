using Odev27_Employee.Models;

namespace Odev27_Employee;

class Program
{
    static void Main(string[] args)
    {
        Employee employee1 = new Employee("Kemal Arslan")
            {
                EmployeeId = 1,
                Salary = 40000.00m
            };

            Employee empolyee2 = new Employee("Selinay Dereli", "Senior Developer")
            {
                EmployeeId = 2,
                Salary = 95000.00m
            };

            Employee[] employees = { employee1, empolyee2};

            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID       : {emp.EmployeeId}");
                Console.WriteLine($"Ad Soyad : {emp.FullName}");
                Console.WriteLine($"Pozisyon : {emp.Position}");
                Console.WriteLine($"Maaş     : {emp.Salary} TL");
                Console.WriteLine("------------------------");
            }

    }
}
