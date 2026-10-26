using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EShopApp.Models.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = null!;
}
