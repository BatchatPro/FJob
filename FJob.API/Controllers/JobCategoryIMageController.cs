using FJob.Access.DTOs;
using FJob.Access.Models;
using FJob.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FJob.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class JobCategoryImageController : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public JobCategoryImageController(UserManager<User> userManager, RoleManager<Role> roleManager, FJobDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpGet]
    [Route("Job/GetAllJobs")]
    public async Task<IActionResult> UploadCategoryImage(string categoryId) => Ok("It is working");

}
