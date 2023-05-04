using FJob.Access.Models;
using FJob.Repository;
using FJob.Shared;
using FJob.Service.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FJob.Repository.Models;

namespace FJob.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public WorkerController(FJobDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    [Route("Worker/GetAllWorkers")]
    public async Task<ActionResult<IEnumerable<WorkerDTO>>> GetAllWorkers()
    {

        IEnumerable<WorkerDTO> workers = (await _context.Workers.ToListAsync()).ConvertToDTO();
        foreach (var worker in workers)
        {
            var author = await _userManager.FindByIdAsync(worker.CreatedBy);

            if (author == null)
                return BadRequest("Invalid user. User didn't fild in Users.");

            worker.Age = DateTime.Now.Year - author.BirthDate.Year;
            worker.Location = author.Location;
            worker.Gender = author.Gender;
        }
        return Ok(workers);
    }

    [HttpGet]
    [Route("Worker/GetWorkersById/{id}")]
    public async Task<ActionResult<WorkerDTO>> GetWorkerById(int id)
    {
        var worker_base = await _context.Workers.FindAsync(id);
        var worker = worker_base.ConvertToDTO();

        var author = await _userManager.FindByIdAsync(worker.CreatedBy);
        if (author == null) return BadRequest();

        worker.Age = DateTime.Now.Year - author.BirthDate.Year;
        worker.Location = author.Location;
        worker.Gender = author.Gender;

        return worker;
    }

    [Authorize(Roles = RoleConst.EMPLOYEE)]
    [HttpPost]
    [Route("Worker/CreateWorker")]
    public async Task<ActionResult<WorkerDTO>> CreateWorker([FromBody] WorkerDTO worker)
    {
        if (worker == null) return BadRequest();

        var userName = _userManager.GetUserId(User);
        var author = await _userManager.FindByNameAsync(userName);

        if (author == null)
            return BadRequest("Invalid user. User didn't fild in Users.");

        worker.CreatedBy = author.Id;
        worker.CreateDate = DateTime.Now;
        worker.UpdatedBy = null;

        _context.Workers.Add(worker.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetWorkerById), new { id = worker.Id }, worker);
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpDelete]
    [Route("Worker/DeleteWorker/{id}")]
    public async Task<ActionResult<WorkerDTO>> DeleteWorker(int id)
    {
        var worker = await _context.Workers.FindAsync(id);
        if (worker == null)
            return NotFound();
        _context.Workers.Remove(worker);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.EMPLOYEE)]
    [HttpPut]
    [Route("Worker/UpdateWorker")]
    public async Task<ActionResult<WorkerDTO>> UpdateWorker([FromBody] WorkerDTO worker)
    {
        var worker_base = await _context.Workers.FindAsync(worker.Id);
        if (worker_base == null)
            return NotFound();

        var userName = _userManager.GetUserId(User);
        var author = await _userManager.FindByNameAsync(userName);

        if (author == null || author.Id != worker_base.CreatedBy)
            return BadRequest("Invalid user. User didn't fild in Users.");

        worker.CreateDate = worker_base.CreateDate;
        worker.UpdateDate = DateTime.Now;
        worker.CreatedBy = worker_base.CreatedBy;
        worker.UpdatedBy = author.Id;

        _context.Workers.Update(worker.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(worker);
    }
}
