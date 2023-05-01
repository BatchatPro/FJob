using FJob.Access.Models.RepositoryReferences;
using Microsoft.AspNetCore.Identity;
using NullGuard;

namespace FJob.Access.Models;

public class User : IdentityUser
{
    [AllowNull]
    public string? FirstName { get; set; }
    [AllowNull]
    public string? LastName { get; set; }
    [AllowNull]
    public string? MiddleName { get; set; }
    public string Location { get; set; }
    public DateTime BirthDate { get; set; }

    public int DistrictId { get; set; }
    public DistrictReference District { get; set; }
}
