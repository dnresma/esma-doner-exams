using Odev33_Athlete.Models;

namespace Odev33_Athlete;

class Program
{
    static void Main(string[] args)
    {
        Athlete athlete1 = new Athlete("Hidayet Türkoğlu", "Basketbol");
        Athlete athlete2 = new Athlete("Naim Süleymanoğlu", "Halter");

        Athlete athlete3 = new Athlete("Eda Erdem", "Voleybol", "Fenerbahçe", 14);
        Athlete athlete4 = new Athlete("Melissa Vargas", "Voleybol", "Fenerbahçe", 44);

        Athlete[] athletes = {athlete1, athlete2, athlete3, athlete4};

        foreach (var athlete in athletes)
        {
            if(athlete.TeamName == string.Empty)
            {
                
                Console.WriteLine("Takımsız Sporcular");
                Console.WriteLine($"Sporcu Adı   :{athlete.FullName}");
                Console.WriteLine($"Branş        :{athlete.SportBranch}");
            }
            else
            {   
                Console.WriteLine("Takımlı Sporcular");
                Console.WriteLine($"Sporcu Adı   :{athlete.FullName}");
                Console.WriteLine($"Branş        :{athlete.SportBranch}");
                Console.WriteLine($"Takım        :{athlete.TeamName}");
                Console.WriteLine($"Numara       :{athlete.JerseyNumber}");
            }
            Console.WriteLine("-----------------------------------");
        }
        
    }
}
