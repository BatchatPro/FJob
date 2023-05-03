using FJob.Access.Models;
using FJob.Service.Mapper;
using FJob.Repository;
using FJob.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FJob.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class JobCategoryController : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public JobCategoryController(UserManager<User> userManager, RoleManager<Role> roleManager, FJobDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    [HttpGet]
    [Route("Category/GetAllCategories")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories() => Ok((await _context.Categories.ToListAsync()).ConvertToDTO());


    [HttpGet]
    [Route("Category/GetCategoryById/{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        return (category == null) ? NotFound() : category.ConvertToDTO();
    }


    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpPost]
    [Route("Category/CreateCategory")]
    public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CategoryDTO category)
    {
        if (category == null) return BadRequest();

        _context.Categories.Add(category.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }


    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpDelete]
    [Route("Category/DeleteCategory/{id}")]
    public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpPut]
    [Route("Category/UpdateCategory")]
    public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] CategoryDTO category)
    {
        if (!_context.Categories.Any(e => e.Id == category.Id))
            return NotFound();
        _context.Categories.Update(category.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(category);
    }

}
