using Odev01_LibraryBook.Models;

namespace Odev01_LibraryBook;

class Program
{
    static void Main(string[] args)
    {
        
        Books book1 = new Books("İnce Memed", "Yaşar Kemal");
        Books book2 = new Books("Kürk Mantolu Madonna", "Sebahattin Ali");
        Books book3 = new Books("Nutuk", "Mustafa Kemal Atatürk");

        Console.WriteLine($"Kütüphanede bulunan kitaplar: \n{book1.Title} ({book1.Author}) \n{book2.Title} ({book2.Author}) \n{book3.Title} ({book3.Author})"); 
        Console.WriteLine("***************************************");

        book1.BorrowBook(); // book1 ödünç alındı
        book2.BorrowBook(); // book2 ödünç alındı
        book1.ReturnBook(); // book1 iade edildi
        book3.BorrowBook(); // book3 ödünç alındı
        book1.ReturnBook(); // zaten kütüphanede olduğu için hata fırlatacak
        

    }
}
