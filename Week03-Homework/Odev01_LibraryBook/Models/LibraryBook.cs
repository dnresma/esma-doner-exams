using System;

namespace Odev01_LibraryBook.Models;

public class Books
{
    public Books(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true; //Yeni oluşturulan kitaplar varsayılan olarak müsaittir.
    }
    public string Title { get; set; }   
    public string Author { get; set; }  
    private bool isAvailable; 
    public bool IsAvailable 
    { 
        get {return isAvailable; }
        private set { isAvailable = value; }
    }

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            Console.WriteLine($"\"{Title}\" kitabı ödünç alabilirsiniz.");
            Console.WriteLine("--------------------------------------");
            IsAvailable = false;
        }
        else
        {
            throw new ArgumentException($"\"{Title}\" kitabı şu anda ödünç alınamaz.");
        }
    }

    public void ReturnBook()
    {
        if (!IsAvailable)
        {
            Console.WriteLine($"\"{Title}\" kitabı iade edildi.");
            Console.WriteLine("--------------------------------------");
            IsAvailable = true;
        }
        else
        {
            throw new ArgumentException($"\"{Title}\" kitabı zaten kütüphanede mevcut.");
        }
    }

}
