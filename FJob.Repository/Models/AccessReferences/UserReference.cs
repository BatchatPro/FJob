using Microsoft.AspNetCore.Identity;
using NullGuard;

namespace FJob.Repository.Models.AccessReferences;

public class UserReference : IdentityUser
{
    [AllowNull]
    public string? LastName { get; set; }
    [AllowNull]
    public string? FirstName { get; set; }
    [AllowNull]
    public string? MiddleName { get; set; }
    public string Location { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<UserSocialLink> UserSocialLinks { get; set; }
}
