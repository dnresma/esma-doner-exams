namespace Odev17_Patient.Models;

class Program
{
    static void Main(string[] args)
    {
        Patient patient1 = new Patient(1, "Kemal Armalı", new DateTime(1990, 1, 1), "O+");
        Patient patient2 = new Patient(2, "Ahmet Yılmaz", new DateTime(1985, 5, 15), "A-");

        Console.WriteLine("Hasta Bilgileri:");
        Console.WriteLine($"{patient1.PatientId}. Hasta ==>, İsim Soyisim: {patient1.FullName}, Kan Grubu: {patient1.BloodType}");
        Console.WriteLine($"{patient2.PatientId}. Hasta ==>, İsim Soyisim: {patient2.FullName}, Kan Grubu: {patient2.BloodType}");

    }
}
