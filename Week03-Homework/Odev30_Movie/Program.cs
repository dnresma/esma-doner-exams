using Odev30_Movie.Models;

namespace Odev30_Movie;

class Program
{
    static void Main(string[] args)
    {
        Movie movie1 = new Movie("Yüzüklerin Efendisi", "Peter Jakson");
        movie1.Rating = 4.80;
        
        Movie movie2 = new Movie("Harry Potter", "David Yates", 130);
        movie2.Rating = 4.70;

        Movie[] movies = {movie1, movie2};

        foreach (Movie movie in movies)
        {
            Console.WriteLine($"Film     : {movie.Title}");
            Console.WriteLine($"Yönetmen : {movie.Director}");
            Console.WriteLine($"Süre     : {movie.DurationMinutes} DK");
            Console.WriteLine($"Reyting  : {movie.Rating}");
            Console.WriteLine("-------------------------------");
            
        }
    }
}
