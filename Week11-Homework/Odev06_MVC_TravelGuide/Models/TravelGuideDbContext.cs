using System;
using Microsoft.EntityFrameworkCore;
using Odev06_MVC_TravelGuide.Models.Entities;

namespace Odev06_MVC_TravelGuide.Models;

public class TravelGuideDbContext : DbContext
{
    public DbSet<Place> Places { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12600;Database=travel_db;Username=travel_user;Password=travel_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Place>().HasData(
            new Place { Id = 1, Name = "Topkapı Sarayı Müzesi", City = "İstanbul", EntryFee = 1500 },
            new Place { Id = 2, Name = "Anıtkabir", City = "Ankara", EntryFee = 0 },
            new Place { Id = 3, Name = "Efes Antik Kenti", City = "İzmir", EntryFee = 1250 },
            new Place { Id = 4, Name = "Yerebatan Sarnıcı", City = "İstanbul", EntryFee = 900 },
            new Place { Id = 5, Name = "Sümela Manastırı", City = "Trabzon", EntryFee = 450 },
            new Place { Id = 6, Name = "Düden Şelalesi", City = "Antalya", EntryFee = 50 },
            new Place { Id = 7, Name = "Pamukkale Travertenleri", City = "Denizli", EntryFee = 700 },
            new Place { Id = 8, Name = "Atatürk Orman Çiftliği", City = "Ankara", EntryFee = 0 },
            new Place { Id = 9, Name = "Göreme Açık Hava Müzesi", City = "Nevşehir", EntryFee = 1000 },
            new Place { Id = 10, Name = "Emirgan Korusu", City = "İstanbul", EntryFee = 0 }
        );
    }
}
