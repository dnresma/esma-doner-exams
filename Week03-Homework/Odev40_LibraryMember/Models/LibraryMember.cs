using System;

namespace Odev40_LibraryMember.Models;

public class LibraryMember
{
    public LibraryMember(int memberId, string? fullName,  DateTime registrationDate)
    {
        MemberId = memberId;
        FullName = fullName;
        MembershipType = "Standard";
        RegistrationDate = registrationDate;
    }

    public LibraryMember(int memberId, string? fullName, string? membershipType, DateTime registrationDate, int barrowedBookCount)
    {
        MemberId = memberId;
        FullName = fullName;
        MembershipType = membershipType;
        RegistrationDate = registrationDate;
        BarrowedBookCount = barrowedBookCount;
    }

    public int MemberId { get; set; }
    public string? FullName { get; set; }
    public string? MembershipType { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int BarrowedBookCount { get; set; }
}
