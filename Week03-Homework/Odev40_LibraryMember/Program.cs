using Odev40_LibraryMember.Models;

namespace Odev40_LibraryMember;

class Program
{
    static void Main(string[] args)
    {
        LibraryMember member1 = new LibraryMember(47743, "Ayla Kır", DateTime.Now);

        LibraryMember member2 = new LibraryMember(46535, "Serkan Tan", "Premium", DateTime.Now, 257);

        LibraryMember[] members = {member1, member2};

        foreach (var member in members)
        {
            Console.WriteLine($"{member.FullName} | {member.MembershipType} | {member.RegistrationDate}");
        }
    }
}
