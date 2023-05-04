using FJob.Access.Models;
using FJob.Repository;
using FJob.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FJob.Service.Mapper;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace FJob.API.Controllers;

[ApiController]
[Route("job/[controller]")]
public class JobController : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;   

    public JobController(FJobDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    [Route("Job/GetAllJobs")]
    public async Task<ActionResult<IEnumerable<JobDTO>>> GetAllJobs() => Ok((await _context.Jobs.ToListAsync()).ConvertToDTO());

    [HttpGet]
    [Route("Job/GetJobsById/{id}")]
    public async Task<ActionResult<JobDTO>> GetJobById(int id)
    {
        var job = await _context.Jobs.FindAsync(id);

        return (job == null) ? NotFound() : job.ConvertToDTO();
    }

    [Authorize(Roles = RoleConst.EMPLOYER)]
    [HttpPost]
    [Route("Job/CreateJob")]
    public async Task<ActionResult<JobDTO>> CreateJob([FromBody] JobDTO job)
    {
        if (job == null) return BadRequest();

        var userName = _userManager.GetUserId(User);
        var author = await _userManager.FindByNameAsync(userName);

        if (author == null)
            return BadRequest("Invalid user. User didn't fild in Users.");

        job.CreatedBy = author.Id;
        job.CreateDate = DateTime.Now;
        job.UpdatedBy = null;

        _context.Jobs.Add(job.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpDelete]
    [Route("Job/DeleteJob/{id}")]
    public async Task<ActionResult<JobDTO>> DeleteJob(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null)
            return NotFound();
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.EMPLOYER)]
    [HttpPut]
    [Route("Job/UpdateJob")]
    public async Task<ActionResult<JobDTO>> UpdateJob([FromBody] JobDTO job)
    {
        var job_base = await _context.Jobs.FindAsync(job.Id);
        if (job_base == null)
            return NotFound();

        var userName = _userManager.GetUserId(User);
        var author = await _userManager.FindByNameAsync(userName);

        if (author == null || author.Id != job_base.CreatedBy)
            return BadRequest("Invalid user. User didn't fild in Users.");

        job.CreateDate = job_base.CreateDate;
        job.UpdateDate = DateTime.Now;
        job.CreatedBy = job_base.CreatedBy;
        job.UpdatedBy = author.Id;

        _context.Jobs.Update(job.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(job);
    }

}