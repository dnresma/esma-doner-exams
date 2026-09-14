using Odev36_Pet.Models;

namespace Odev36_Pet;

class Program
{
    static void Main(string[] args)
    {
        Pet pet1 = new Pet("Mia", "Esma Döner");

        Pet pet2 = new Pet("Çiko", "Kedi", 5,  "Elif Demir");

        Pet[] pets = {pet1, pet2};

        foreach (var pet in pets)
        {
            Console.WriteLine($"İsim   : {pet.Name}");
            Console.WriteLine($"Tür    : {pet.Type}");
            Console.WriteLine($"Yaş    : {pet.Age}");
            Console.WriteLine($"Sahip İsmi   : {pet.OwnerName}");
            Console.WriteLine("******************************");
        }
    }
}
