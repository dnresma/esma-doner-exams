using System;

namespace Odev04_MVC_GymMembers.Models.Entities;

public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string MemberShipType { get; set; } = null!;
    public int Age { get; set; }
}
