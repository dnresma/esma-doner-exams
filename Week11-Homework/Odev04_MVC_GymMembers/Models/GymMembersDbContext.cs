using System;
using Microsoft.EntityFrameworkCore;
using Odev04_MVC_GymMembers.Models.Entities;

namespace Odev04_MVC_GymMembers.Models;

public class GymMembersDbContext : DbContext
{
    public DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12400;Database=gym_db;Username=gym_user;Password=gym_password");
        // Veri tabanına bağlantı metodu
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Member>().HasData(
            new Member { Id = 1, FullName = "Ahmet Yılmaz", MemberShipType = "Aylık", Age = 28 },
            new Member { Id = 2, FullName = "Ayşe Kaya", MemberShipType = "Yıllık", Age = 34 },
            new Member { Id = 3, FullName = "Mehmet Demir", MemberShipType = "3 Aylık", Age = 22 },
            new Member { Id = 4, FullName = "Zeynep Çelik", MemberShipType = "Aylık", Age = 41 },
            new Member { Id = 5, FullName = "Can Öztürk", MemberShipType = "Yıllık", Age = 29 },
            new Member { Id = 6, FullName = "Elif Şahin", MemberShipType = "3 Aylık", Age = 25 },
            new Member { Id = 7, FullName = "Burak Arslan", MemberShipType = "Aylık", Age = 33 },
            new Member { Id = 8, FullName = "Seda Aydın", MemberShipType = "Yıllık", Age = 37 },
            new Member { Id = 9, FullName = "Emre Yıldız", MemberShipType = "3 Aylık", Age = 20 },
            new Member { Id = 10, FullName = "Merve Koç", MemberShipType = "Yıllık", Age = 31 }
        );
    }
}
