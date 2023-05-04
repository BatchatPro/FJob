using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class NewsMapper
{
    public static NewsDTO ConvertToDTO(this News model)
    {
        if (model == null)
            return null;
        return new NewsDTO()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            ViewsCount = model.ViewsCount,
            CreateDate = model.CreateDate
        };
    }

    public static News ConvertToEntity(this NewsDTO model)
    {
        if (model == null)
            return null;
        return new News()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            ViewsCount = model.ViewsCount,
            CreateDate = model.CreateDate
        };
    }

    public static IEnumerable<NewsDTO> ConvertToDTO(this IEnumerable<News> models)
    {
        if (models == null)
            return null;
        return models.Select(model => new NewsDTO()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            ViewsCount = model.ViewsCount,
            CreateDate = model.CreateDate
        });
    }

    public static IEnumerable<News> ConvertToEntity(this IEnumerable<NewsDTO> models)
    {
        if (models == null)
            return null;
        return models.Select(model => new News()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            ViewsCount = model.ViewsCount,
            CreateDate = model.CreateDate
        });
    }

}
