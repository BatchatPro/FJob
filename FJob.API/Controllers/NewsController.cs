using FJob.Repository;
using FJob.Shared;
using FJob.Service.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FJob.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly FJobDbContext _context;

    public NewsController(FJobDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("News/GetAllNews")]
    public async Task<ActionResult<IEnumerable<NewsDTO>>> GetAllNews() => Ok((await _context.News.ToListAsync()).ConvertToDTO());


    [HttpGet]
    [Route("News/GetNewsById/{id}")]
    public async Task<ActionResult<NewsDTO>> GetNewsById(int id)
    {
        var news = await _context.News.FindAsync(id);

        return (news == null) ? NotFound() : news.ConvertToDTO();
    }


    [HttpPost]
    [Route("News/CreateNews")]
    public async Task<ActionResult<NewsDTO>> CreateNews([FromBody] NewsDTO news)
    {
        if (news == null) return BadRequest();

        _context.News.Add(news.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpDelete]
    [Route("News/DeleteNews/{id}")]
    public async Task<ActionResult<NewsDTO>> DeleteCategory(int id)
    {
        var news = await _context.News.FindAsync(id);
        if (news == null)
            return NotFound();
        _context.News.Remove(news);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpPut]
    [Route("News/UpdateNews")]
    public async Task<ActionResult<NewsDTO>> UpdateNews([FromBody] NewsDTO news)
    {
        if (!_context.News.Any(e => e.Id == news.Id))
            return NotFound();
        _context.News.Update(news.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(news);
    }

}
