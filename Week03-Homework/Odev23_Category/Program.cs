using Odev23_Category.Models;

namespace Odev23_Category;

class Program
{
    static void Main(string[] args)
    {
        Category category1 = new Category("Bilgisayar");
        category1.Description = "Masaüstü ve dizüstü bilgisayar modelleri";

        Category category2 = new Category("Telefon","Samsung, Apple, Xiaomi birçok marka telefon modelleri");

        Console.WriteLine($"Kategori ismi: {category1.Name}  \nAçıklama: {category1.Description}");
        Console.WriteLine("*********************************");
        Console.WriteLine($"Kategori ismi: {category2.Name}  \nAçıklama: {category2.Description}");
    }
}
