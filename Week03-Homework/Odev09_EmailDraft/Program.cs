using Odev09_EmailDraft.Models;

namespace Odev09_EmailDraft;

class Program
{
    static void Main(string[] args)
    {
        EmailDraft emailDraft = new EmailDraft("infotechacademy@gmail.com","homework","Bu içerikte ödevlerim bulunmaktadır.");
        Console.WriteLine($"To: {emailDraft.To}");
        Console.WriteLine($"Subject: {emailDraft.Subject}");    
        Console.WriteLine($"Body: {emailDraft.Body}");
        emailDraft.Update("Bu içerikte ödevlerim bulunmaktadır. Lütfen kontrol ediniz.");
        Console.WriteLine($"Updated Body: {emailDraft.Body}");
        emailDraft.Send("infotechacademy@gmail.com", "");
        


    }
}
