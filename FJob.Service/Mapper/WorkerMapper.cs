using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class WorkerMapper
{
    public static WorkerDTO ConvertToDTO(this Worker model)
    {
        if (model == null)
            return null;
        return new WorkerDTO()
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
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        };
    }

    public static Worker ConvertToEntity(this WorkerDTO model)
    {
        if (model == null)
            return null;
        return new Worker()
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
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        };
    }

    public static IEnumerable<WorkerDTO> ConvertToDTO(this IEnumerable<Worker> models)
    {
        if (models == null)
            return null;
        return models.Select(model => new WorkerDTO()
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
            CreatedBy = model.CreatedBy,
            UpdatedBy = model.UpdatedBy,
            DistrictId = model.DistrictId,
            CategoryId = model.CategoryId,
        });
    }

}
