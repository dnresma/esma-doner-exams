using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Odev09_EmailDraft.Models;

public class EmailDraft
{
    public EmailDraft(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }
    private string to = string.Empty;
    private string subject = string.Empty;
    private string body = string.Empty;
    private bool isSent;

    public string To 
    { 
        get { return to; } 
        set { to = value; } 
    }
    public string Subject 
    { 
        get { return subject; }
        set { subject = value; }
    }
    public string Body 
    { 
        get { return body; } 
        set { body = value; }
    }    
    public bool IsSent 
    { 
        get { return isSent; }
        private set { isSent = value; }
    }
    public void Update(string newBody)
    {
        if(IsSent)
        {
            throw new ArgumentException("Mesaj gönderildiği için güncellenemez.");
        }
        Body = newBody;
    }
    public bool Send(string to, string subject)
    {
        if (string.IsNullOrEmpty(To) || string.IsNullOrEmpty(Subject) || To.Contains(string.Empty) || Subject.Contains(string.Empty))
        {
            throw new ArgumentException("Alıcı ve Konu alanları boş bırakılamaz!");
        }
        IsSent = true;
        Console.WriteLine($"E-posta '{To}' adresine başarıyla gönderildi.");
        return true;
    }

}


