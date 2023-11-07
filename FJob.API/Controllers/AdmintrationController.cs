using FJob.Access.Models;
using FJob.Access.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FJob.Access.DTOs;

namespace FJob.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AdmintrationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public AdmintrationController(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
    }


    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpGet]
    [Route("User/GetAllUsers")]
    public async Task<IActionResult> GetAllUsers() => Ok((await _userManager.Users.ToListAsync()).ConvertToDTO());


    [HttpGet("User/GetUserById{Id:Guid}")]
    public async Task<IActionResult> GetUserById(Guid Id)
    {
        User user = await _userManager.FindByIdAsync(Convert.ToString(Id));
        return (user == null) ? NotFound() : Ok(user.ConvertToDTO());
    }


    [HttpGet]
    [Route("User/GetRolesByUserId{Id:Guid}")]
    public async Task<IActionResult> GetUserRolesById(Guid Id)
    {
        User user = await _userManager.FindByIdAsync(Convert.ToString(Id));
        IEnumerable<string> roles = await _userManager.GetRolesAsync(user);

        return (roles == null) ? NotFound() : Ok(new
        {
            userId = user.Id,
            access = roles,
        });

    }


    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpPost]
    [Route("User/CreateUser")]
    public async Task<IActionResult> CreateAccount([FromBody] RegistrationDTO userDTO)
    {
        if (userDTO.Role != RoleConst.EMPLOYEE && userDTO.Role != RoleConst.EMPLOYER)
            return BadRequest("Wrong Role! You have to select 'employee' or 'employer'.");
        try
        {
            User user = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                MiddleName = userDTO.MiddleName,
                PhoneNumber = userDTO.PhoneNumber,
                Location = userDTO.Location,
                BirthDate = userDTO.BirthDate,
                Gender = userDTO.Gender,
            };
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                throw new BadHttpRequestException(result.Errors.Select(x => x.Description).ToString());

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, new string[] { RoleConst.NEWUSER, userDTO.Role });

            return Ok(userDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpPut]
    [Route("User/AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] UserRolesDTO userRolesDTO)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userRolesDTO.UserId);
            IList<string> addingRoles = new List<string>();
            foreach (var role in userRolesDTO.Roles)
                addingRoles.Add(role.Name);

            var result = await _userManager.AddToRolesAsync(user, addingRoles);

            if (!result.Succeeded)
                throw new BadHttpRequestException(result.Errors.Select(x => x.Description).ToString());

            var userRoles = await _userManager.GetRolesAsync(user);

            IList<RoleDTO> rolesDTOs = new List<RoleDTO>();
            foreach (var role in userRoles)
            {
                var userRole = await _roleManager.FindByNameAsync(role);
                rolesDTOs.Add(userRole.ConvertToDTO());
            }

            userRolesDTO.Roles = rolesDTOs;
            return Ok(userRolesDTO);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpDelete]
    [Route("User/RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser(UserRolesDTO userRolesDTO)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userRolesDTO.UserId);

            IList<string> removingRoles = new List<string>();

            foreach (var role in userRolesDTO.Roles)
                removingRoles.Add(role.Name);

            var result = await _userManager.RemoveFromRolesAsync(user, removingRoles);

            if (!result.Succeeded)
                throw new BadHttpRequestException(result.Errors.Select(x => x.Description).ToString());

            var userRoles = await _userManager.GetRolesAsync(user);

            IList<RoleDTO> rolesDTO = new List<RoleDTO>();
            foreach (var role in userRoles)
            {
                var userRole = await _roleManager.FindByNameAsync(role);
                rolesDTO.Add(userRole.ConvertToDTO());
            }

            userRolesDTO.Roles = rolesDTO;
            return Ok(userRolesDTO);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    [Route("User/UpdateProfile")]
    public async Task<IActionResult> ChangeUser([FromBody] UpdateProfileDTO userDTO)
    {
        var userName = _userManager.GetUserId(User);
        var _user = await _userManager.FindByNameAsync(userName);
        if (_user.Id == null || (!User.IsInRole(RoleConst.ADMIN) && _user.Id != userDTO.Id))
            return Forbid();

        User user = await _userManager.FindByIdAsync(userDTO.Id);
        if (user == null)
            return NotFound();

        user.LastName = userDTO.LastName;
        user.FirstName = userDTO.FirstName;
        user.MiddleName = userDTO.MiddleName;
        user.PhoneNumber = userDTO.PhoneNumber;
        user.Email = userDTO.Email;
        user.BirthDate = userDTO.BirthDate;
        user.Location = userDTO.Location;
        user.Gender = userDTO.Gender;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return BadRequest(new { Successful = false, Errors = result.Errors.Select(x => x.Description) });

        if (userDTO.Password == userDTO.ConfirmPassword && user != null)
        {
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, userDTO.Password);
        }

        return Ok(user.ConvertToDTO());
    }


}


