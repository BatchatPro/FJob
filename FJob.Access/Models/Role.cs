using Microsoft.AspNetCore.Identity;

namespace FJob.Access.Models;

public class Role : IdentityRole
{
    public Role() { }
    public Role(string roleName, string description)
    {
        Name = roleName;
        Description = description;
    }
    public string Description { get; set; }
}
