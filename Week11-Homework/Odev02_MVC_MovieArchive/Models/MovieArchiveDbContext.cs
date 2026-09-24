using System;
using Microsoft.EntityFrameworkCore;
using Odev02_MVC_MovieArchive.Models.Entities;

namespace Odev02_MVC_MovieArchive.Models;

public class MovieArchiveDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12200;Database=movie_db;Username=movie_user;Password=movie_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Babam ve Oğlum", Director = "Çağan Irmak", ReleaseYear = 2005 },
            new Movie { Id = 2, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 },
            new Movie { Id = 3, Title = "Eşkıya", Director = "Yavuz Turgul", ReleaseYear = 1996 },
            new Movie { Id = 4, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972 },
            new Movie { Id = 5, Title = "G.O.R.A.", Director = "Ömer Faruk Sorak", ReleaseYear = 2004 },
            new Movie { Id = 6, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994 },
            new Movie { Id = 7, Title = "Vizontele", Director = "Yılmaz Erdoğan, Ömer Faruk Sorak", ReleaseYear = 2001 },
            new Movie { Id = 8, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008 },
            new Movie { Id = 9, Title = "Bir Zamanlar Anadolu'da", Director = "Nuri Bilge Ceylan", ReleaseYear = 2011 },
            new Movie { Id = 10, Title = "Interstellar", Director = "Christopher Nolan", ReleaseYear = 2014 }
        );
    }
}
