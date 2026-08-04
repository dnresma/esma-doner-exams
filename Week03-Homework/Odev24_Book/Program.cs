namespace Odev24_Book.Models;

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book();
        book1.Name = "İnce Memed";
        book1.AuthorName = "Yaşar Kemal";
        book1.PageCount = 410;

        Book book2 = new Book("Şeker Portakalı");
        book2.AuthorName = "José Mauro de Vasconcelos";

        Book book3 = new Book("Simyacı", "Paulo Coelho");
        book3.PageCount = 270;

        Book book4 = new Book("1984", "George Orwell", "Roman");
        book4.PageCount = 400;

        Book book5 = new Book("Suç ve Ceza", "Dostoyevski", "Klasik", 687);

    
        Console.WriteLine($"1. Kitap -> Ad: {book1.Name} | Yazar: '{book1.AuthorName}' | Sayfa Sayısı: {book1.PageCount}");
        Console.WriteLine($"2. Kitap -> Ad: {book2.Name} | Yazar: '{book2.AuthorName}' | Sayfa Sayısı: {book2.PageCount}");
        Console.WriteLine($"3. Kitap -> Ad: {book3.Name} | Yazar: {book3.AuthorName} | Sayfa Sayısı: {book3.PageCount}");
        Console.WriteLine($"4. Kitap -> Ad: {book4.Name} | Yazar: {book4.AuthorName} | Sayfa Sayısı: {book4.PageCount}");
        Console.WriteLine($"5. Kitap -> Ad: {book5.Name} | Yazar: {book5.AuthorName} | Sayfa Sayısı: {book5.PageCount}");
    }
    
}
