using System;
using Microsoft.EntityFrameworkCore;
using Odev05_MVC_CafeMenu.Models.Entities;

namespace Odev05_MVC_CafeMenu.Models;

public class CafeMenuDbContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12500;Database=cafe_db;Username=cafe_user;Password=cafe_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Türk Kahvesi", Category = "Sıcak İçecek", Price = 75 },
            new MenuItem { Id = 2, Name = "Espresso", Category = "Sıcak İçecek", Price = 80 },
            new MenuItem { Id = 3, Name = "Iced Latte", Category = "Soğuk İçecek", Price = 110 },
            new MenuItem { Id = 4, Name = "Ev Yapımı Limonata", Category = "Soğuk İçecek", Price = 95 },
            new MenuItem { Id = 5, Name = "San Sebastian Cheesecake", Category = "Tatlı", Price = 180 },
            new MenuItem { Id = 6, Name = "Tiramisu", Category = "Tatlı", Price = 160 },
            new MenuItem { Id = 7, Name = "Demleme Çay", Category = "Sıcak İçecek", Price = 35 },
            new MenuItem { Id = 8, Name = "Ice Americano", Category = "Soğuk İçecek", Price = 100 },
            new MenuItem { Id = 9, Name = "Sıcak Çikolata", Category = "Sıcak İçecek", Price = 120 },
            new MenuItem { Id = 10, Name = "Havuçlu Kek", Category = "Tatlı", Price = 130 }
        );
    }
}
