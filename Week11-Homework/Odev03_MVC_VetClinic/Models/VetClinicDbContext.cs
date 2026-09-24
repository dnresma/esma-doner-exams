using System;
using Microsoft.EntityFrameworkCore;
using Odev03_MVC_VetClinic.Models.Entities;

namespace Odev03_MVC_VetClinic.Models;

public class VetClinicDbContext : DbContext
{
    public DbSet<Vet> Vets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12300;Database=vet_db;Username=vet_user;Password=vet_password");
        // Veri tabanına bağlantı metodu)
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Vet>().HasData(
            new Vet { Id = 1, Name = "Karabaş", Species = "Köpek", Age = 5 },
            new Vet { Id = 2, Name = "Pamuk", Species = "Kedi", Age = 3 },
            new Vet { Id = 3, Name = "Maviş", Species = "Kuş", Age = 2 },
            new Vet { Id = 4, Name = "Minnoş", Species = "Kedi", Age = 4 },
            new Vet { Id = 5, Name = "Çakıl", Species = "Köpek", Age = 7 },
            new Vet { Id = 6, Name = "Boncuk", Species = "Tavşan", Age = 1 },
            new Vet { Id = 7, Name = "Fındık", Species = "Hamster", Age = 2 },
            new Vet { Id = 8, Name = "Leo", Species = "Köpek", Age = 6 },
            new Vet { Id = 9, Name = "Zeytin", Species = "Kedi", Age = 5 },
            new Vet { Id = 10, Name = "Limon", Species = "Papağan", Age = 3 }
        );
    }
}
