using FJob.Access.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FJob.API;

public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
{
    public MyUserClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor) { }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName));
        identity.AddClaim(new Claim("UserName", user.UserName));
        identity.AddClaim(new Claim("Email", user.Email));
        return identity;
    }
}
