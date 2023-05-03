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
public class AddressContoller : ControllerBase
{
    private readonly FJobDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public AddressContoller(UserManager<User> userManager, RoleManager<Role> roleManager, FJobDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    #region Regions
    [HttpGet]
    [Route("Region/GetAllRegions")]
    public async Task<ActionResult<IEnumerable<RegionDTO>>> GetAllRegions() => Ok((await _context.Regions.ToListAsync()).ConvertToDTO());

    [HttpGet]
    [Route("Region/GetRegionById/{id}")]
    public async Task<ActionResult<RegionDTO>> GetRegionById(int id)
    {
        var region = await _context.Regions.FindAsync(id);

        return (region == null) ? NotFound() : region.ConvertToDTO() ;
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpPost]
    [Route("Region/CreateRegion")]
    public async Task<ActionResult<RegionDTO>> CreateRegion([FromBody]RegionDTO region)
    {
        if (region == null) return BadRequest();

        _context.Regions.Add(region.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRegionById), new {id =  region.Id}, region);
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpDelete]
    [Route("Region/DeleteRegion/{id}")]
    public async Task<ActionResult<RegionDTO>> DeleteRegion(int id)
    {
        var region = await _context.Regions.FindAsync(id);
        if (region == null)
            return NotFound();
        _context.Regions.Remove(region);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpPut]
    [Route("Region/UpdateRegion")]
    public async Task<ActionResult<RegionDTO>> UpdateRegion([FromBody]RegionDTO region)
    {
        if (!_context.Regions.Any(e => e.Id == region.Id))
            return NotFound();
        _context.Regions.Update(region.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(region);
    }
    #endregion

    #region Districts
    [HttpGet]
    [Route("District/GetAllDistricts")]
    public async Task<ActionResult<IEnumerable<DistrictDTO>>> GetAllDistricts() => Ok((await _context.Districts.ToListAsync()).ConvertToDTO());

    [HttpGet]
    [Route("District/GetDistrictById/{id}")]
    public async Task<ActionResult<DistrictDTO>> GetDistrictById(int id)
    {
        var district = await _context.Districts.FindAsync(id);

        return (district == null) ? NotFound() : district.ConvertToDTO();
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpPost]
    [Route("District/CreateDistrict")]
    public async Task<ActionResult<DistrictDTO>> CreateDistrict([FromBody] DistrictDTO district)
    {
        if (district == null) return BadRequest();

        _context.Districts.Add(district.ConvertToEntity());
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDistrictById), new { id = district.Id }, district);
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpDelete]
    [Route("District/DeleteDistrict/{id}")]
    public async Task<ActionResult<DistrictDTO>> DeleteDistrict(int id)
    {
        var district = await _context.Districts.FindAsync(id);
        if (district == null)
            return NotFound();
        _context.Districts.Remove(district);
        await _context.SaveChangesAsync();
        return NotFound();
    }

    [Authorize(Roles = RoleConst.ADMIN)]
    [HttpPut]
    [Route("Region/UpdateDistrict")]
    public async Task<ActionResult<DistrictDTO>> UpdateDistrict([FromBody] DistrictDTO district)
    {
        if (!_context.Districts.Any(e => e.Id == district.Id))
            return NotFound();
        _context.Districts.Update(district.ConvertToEntity());
        await _context.SaveChangesAsync();

        return Ok(district);
    }
    #endregion
}
