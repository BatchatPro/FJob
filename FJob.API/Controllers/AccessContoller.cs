using FJob.Access.DTOs;
using FJob.Access.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FJob.API.Controllers;

public class AccessController : Controller
{
    private IOptions<AccessConfiguration> _siteSettings;
    private readonly UserManager<User> _userManager;

    public AccessController(IOptions<AccessConfiguration> siteSettings, UserManager<User> userManager)
    {
        this._siteSettings = siteSettings;
        this._userManager = userManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LogInDTO loginModel)
    {
        if(!ModelState.IsValid)
            return BadRequest("Model state isn't valid.");

        User user = await _userManager.FindByNameAsync(loginModel.UserName);
        if(user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
        {
            IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
            List<Claim> authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Vars.TheSecretKey));
            AddRolesToClaims(authClaims, roles);
            var token = new JwtSecurityToken(
                issuer: _siteSettings.Value.Issuer,
                audience: _siteSettings.Value.Audience,
                expires:  DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                userId = user.Id,
                email = user.Email,
                userName = user.UserName,
                firstName = user.FirstName,
                lastName = user.LastName,
                middleName = user.MiddleName,
                phoneNumber = user.PhoneNumber,
                location = user.Location,
                birthDate = user.BirthDate,
                access = roles,
            });
        }
        return Unauthorized();
    }

    private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            var roleClaim = new Claim(ClaimTypes.Role, role);
            claims.Add(roleClaim);
        }
    }

    [HttpPost]
    [Route("signup")]
    public async Task<IActionResult> RegistrationAsync([FromBody] RegistrationDTO model)
    {
        if (model.Role != RoleConst.EMPLOYEE && model.Role != RoleConst.EMPLOYER)
            return BadRequest("Wrong Role! You have to select 'employee' or 'employer'.");

        if (!ModelState.IsValid)
            return BadRequest("Model state isn't valid.");

        User user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null)
            return BadRequest("This user alrady created.");

        User newUser = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            PhoneNumber = model.PhoneNumber,
            Location = model.Location,
            BirthDate = model.BirthDate
        };
        var result = await _userManager.CreateAsync(newUser, model.Password);
        if (result.Succeeded)
            await _userManager.AddToRolesAsync(newUser, new string[] { RoleConst.NEWUSER ,model.Role});
        return Ok(result);
    }

}
