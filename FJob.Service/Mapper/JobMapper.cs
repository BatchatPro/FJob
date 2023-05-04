using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class JobMapper
{
    public static JobDTO ConvertToDTO(this Job model)
    {
        if (model == null)
            return null;
        return new JobDTO()
        {
            Id = model.Id,
            MinSalary = model.MinSalary,
            MaxSalary = model.MaxSalary,
            Deadline = model.Deadline,
            CreateDate = model.CreateDate,
            Demand = model.Demand,
            MoreInfo = model.MoreInfo,
            WorkingTime = model.WorkingTime,
            CallTime = model.CallTime,
            Status = model.Status,
            Title = model.Title,
            Benefit = model.Benefit,
            Location = model.Location,
            MinAge = model.MinAge,
            MaxAge = model.MaxAge,
            Gender = model.Gender,
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        };
    }

    public static Job ConvertToEntity(this JobDTO model)
    {
        if (model == null)
            return null;
        return new Job()
        {
            Id = model.Id,
            MinSalary = model.MinSalary,
            MaxSalary = model.MaxSalary,
            Deadline = model.Deadline,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Demand = model.Demand,
            MoreInfo = model.MoreInfo,
            WorkingTime = model.WorkingTime,
            CallTime = model.CallTime,
            Status = model.Status,
            Title = model.Title,
            Benefit = model.Benefit,
            Location = model.Location,
            MinAge = model.MinAge,
            MaxAge = model.MaxAge,
            Gender = model.Gender,
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        };
    }

    public static IEnumerable<JobDTO> ConvertToDTO(this IEnumerable<Job> models)
    {
        if (models == null)
            return null;
        return models.Select(model => new JobDTO()
        {
            Id = model.Id,
            MinSalary = model.MinSalary,
            MaxSalary = model.MaxSalary,
            Deadline = model.Deadline,
            CreateDate = model.CreateDate,
            UpdateDate = model.UpdateDate,
            Demand = model.Demand,
            MoreInfo = model.MoreInfo,
            WorkingTime = model.WorkingTime,
            CallTime = model.CallTime,
            Status = model.Status,
            Title = model.Title,
            Benefit = model.Benefit,
            Location = model.Location,
            MinAge = model.MinAge,
            MaxAge = model.MaxAge,
            Gender = model.Gender,
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        });
    }

}
