using System;
using Microsoft.EntityFrameworkCore;
using Odev01_MVC_Library.Models.Entities;

namespace Odev01_MVC_Library.Models;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12100;Database=lib_db;Username=lib_user;Password=lib_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Nutuk", Author = "Mustafa Kemal Atatürk", PageCount = 543 },
            new Book { Id = 2, Title = "Suç ve Ceza", Author = "Fyodor Dostoyevski", PageCount = 704 },
            new Book { Id = 3, Title = "Sefiller", Author = "Victor Hugo", PageCount = 1724 },
            new Book { Id = 4, Title = "1984", Author = "George Orwell", PageCount = 352 },
            new Book { Id = 5, Title = "Şeker Portakalı", Author = "José Mauro de Vasconcelos", PageCount = 200 },
            new Book { Id = 6, Title = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", PageCount = 160 },
            new Book { Id = 7, Title = "Simyacı", Author = "Paulo Coelho", PageCount = 184 },
            new Book { Id = 8, Title = "Küçük Prens", Author = "Antoine de Saint-Exupéry", PageCount = 112 },
            new Book { Id = 9, Title = "Dönüşüm", Author = "Franz Kafka", PageCount = 104 },
            new Book { Id = 10, Title = "Tutunamayanlar", Author = "Oğuz Atay", PageCount = 724 }
        );
    }
}
