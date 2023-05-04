using FJob.Repository;
using FJob.Shared;
using FJob.Service.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FJob.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly FJobDbContext _context;

    public ContactController(FJobDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("Contact/GetAllContacts")]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllContacts() => Ok((await _context.Contacts.ToListAsync()).ConvertToDTO());

    [HttpGet]
    [Route("Contact/GetContactById/{id}")]
    public async Task<ActionResult<ContactDTO>> GetContactById(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        return (contact == null) ? NotFound() : contact.ConvertToDTO();
    }

    [HttpPost]
    [Route("Contact/CreateContact")]
    public async Task<ActionResult<ContactDTO>> CreateContact([FromBody] ContactDTO contact)
    {
        if (contact == null) return BadRequest();

        _context.Contacts.Add(contact.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpDelete]
    [Route("Contact/DeleteContact/{id}")]
    public async Task<ActionResult<ContactDTO>> DeleteCategory(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
            return NotFound();
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.SUPERVISOR)]
    [HttpPut]
    [Route("Contact/UpdateContact")]
    public async Task<ActionResult<ContactDTO>> UpdateContact([FromBody] ContactDTO contact)
    {
        if (!_context.Contacts.Any(e => e.Id == contact.Id))
            return NotFound();
        _context.Contacts.Update(contact.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(contact);
    }
}
