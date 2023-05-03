using FJob.Repository.Models;
using FJob.Shared;

namespace FJob.Service.Mapper;

public static class CategoryMapper 
{
    public static CategoryDTO ConvertToDTO(this Category category)
    {
        if (category == null)
            return null;
        return new CategoryDTO()
        {
            Id = category.Id,
            Title = category.Title,
            Descrtiption = category.Description
        };
    }

    public static Category ConvertToEntity(this CategoryDTO categoryDTO)
    {
        if (categoryDTO == null)
            return null;
        return new Category()
        {
            Id = categoryDTO.Id,
            Title = categoryDTO.Title,
            Description = categoryDTO.Descrtiption
        };
    }

    public static IEnumerable<CategoryDTO> ConvertToDTO(this IEnumerable<Category> categories)
    {
        if (categories == null)
            return null;
        return categories.Select(category => new CategoryDTO()
        {
            Id = category.Id,
            Title = category.Title,
            Descrtiption = category.Description
        });
    }

    public static IEnumerable<Category> ConvertToEntity(this IEnumerable<CategoryDTO> categoryDTOs)
    {
        if (categoryDTOs == null)
            return null;
        return categoryDTOs.Select(categoryDTO => new Category()
        {
            Id = categoryDTO.Id,
            Title = categoryDTO.Title,
            Description = categoryDTO.Descrtiption
        });
    }
}
