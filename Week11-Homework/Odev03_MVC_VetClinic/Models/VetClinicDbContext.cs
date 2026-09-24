using System;
using Microsoft.EntityFrameworkCore;
using Odev03_MVC_VetClinic.Models.Entities;

namespace Odev03_MVC_VetClinic.Models;

public class VetClinicDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12300;Database=vet_db;Username=vet_user;Password=vet_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pet>().HasData(
            new Pet { Id = 1, Name = "Karabaş", Species = "Köpek", Age = 5 },
            new Pet { Id = 2, Name = "Pamuk", Species = "Kedi", Age = 3 },
            new Pet { Id = 3, Name = "Maviş", Species = "Kuş", Age = 2 },
            new Pet { Id = 4, Name = "Minnoş", Species = "Kedi", Age = 4 },
            new Pet { Id = 5, Name = "Çakıl", Species = "Köpek", Age = 7 },
            new Pet { Id = 6, Name = "Boncuk", Species = "Tavşan", Age = 1 },
            new Pet { Id = 7, Name = "Fındık", Species = "Hamster", Age = 2 },
            new Pet { Id = 8, Name = "Leo", Species = "Köpek", Age = 6 },
            new Pet { Id = 9, Name = "Zeytin", Species = "Kedi", Age = 5 },
            new Pet { Id = 10, Name = "Limon", Species = "Papağan", Age = 3 }
            );

    }
}
