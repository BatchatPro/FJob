using FJob.Access.Models;
using FJob.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FJob.API.Controllers;

[ApiController]
[Route("job/[controller]")]
public class JobsController : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;

    public JobsController(FJobDbContext context, UserManager<User> userManager)
    {
        _context = context;
        this._userManager = userManager;
    }

    [HttpGet(Name = "GetText")]
    public string GetText()
    {
        return "Salom, barchasi juda a'lo darajada ishlayapti.";
    }
}