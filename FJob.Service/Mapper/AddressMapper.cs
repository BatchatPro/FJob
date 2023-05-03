using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class AddressMapper
{
    #region Regions
    public static RegionDTO ConvertToDTO(this Region region)
    {
        if (region == null)
            return null;
        return new RegionDTO()
        {
            Id = region.Id,
            Name = region.Name,
        };
    }

    public static Region ConvertToEntity(this RegionDTO regionDTO)
    {
        if (regionDTO == null)
            return null;
        return new Region()
        {
            Id = regionDTO.Id,
            Name = regionDTO.Name
        };
    }

    public static IEnumerable<RegionDTO> ConvertToDTO(this IEnumerable<Region> regions)
    {
        if (regions == null)
            return null;
        return regions.Select(region => new RegionDTO()
        {
            Id = region.Id,
            Name = region.Name,
        });
    }

    public static IEnumerable<Region> ConvertToEntity(this IEnumerable<RegionDTO> regionsDTOs)
    {
        if (regionsDTOs == null)
            return null;
        return regionsDTOs.Select(regionDTO => new Region()
        {
            Id = regionDTO.Id,
            Name = regionDTO.Name
        });
    }
    #endregion

    #region Districts
    public static DistrictDTO ConvertToDTO(this District district)
    {
        if (district == null)
            return null;
        return new DistrictDTO()
        {
            Id = district.Id,
            Name = district.Name,
            RegionId = district.RegionId
        };
    }

    public static District ConvertToEntity(this DistrictDTO district)
    {
        if (district == null)
            return null;
        return new District()
        {
            Id = district.Id,
            Name = district.Name,
            RegionId = district.RegionId
        };
    }

    public static IEnumerable<DistrictDTO> ConvertToDTO(this IEnumerable<District> districts)
    {
        if (districts == null)
            return null;
        return districts.Select(district => new DistrictDTO()
        {
            Id = district.Id,
            Name = district.Name,
            RegionId = district.RegionId
        });
    }

    public static IEnumerable<District> ConvertToEntity(this IEnumerable<DistrictDTO> districts)
    {
        if (districts == null)
            return null;
        return districts.Select(district => new District()
        {
            Id = district.Id,
            Name = district.Name,
            RegionId = district.RegionId
        });
    }
    #endregion
}
