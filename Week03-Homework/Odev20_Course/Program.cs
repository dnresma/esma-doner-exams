namespace Odev20_Course.Models;

class Program
{
    static void Main(string[] args)
    {
        List<Course> courses = new List<Course>
            {
                new Course("CS101", "Programlamaya Giriş", "Dr. Engin", 4, true),
                new Course("MATH101", "Matematik 1", "Prof. Ayşe", 3, false),
                new Course("CS102", "Nesne Yönelimli Programlama", "Dr. Engin", 4, true),
                new Course("PHY101", "Fizik 1", "Doç. Hakan", 3, false)
            };

            Console.WriteLine("=== ONLINE DERSLER ===");
            foreach (var c in courses)
            {
                if (c.IsOnline) Console.WriteLine($"{c.CourseCode} - {c.CourseName}");
            }

            Console.WriteLine("\n=== YÜZ YÜZE DERSLER ===");
            foreach (var c in courses)
            {
                if (!c.IsOnline) Console.WriteLine($"{c.CourseCode} - {c.CourseName}");
            }
    }
}
