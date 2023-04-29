using FJob.Access.DTOs;
using FJob.Access.Models;

namespace FJob.Access.Mapper;

public static class MapperExtension
{
    public static UserDTO ConvertToDTO(this User user)
    {
        if (user == null)
            return null;
        return new UserDTO()
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            PhoneNumber = user.PhoneNumber,
            Location = user.Location,
            BirthDate = user.BirthDate,
            Email = user.Email
        };
    }
    
    public static User ConvertToEntity(this UserDTO userDTO)
    {
        if (userDTO == null)
            return null;
        return new User()
        {
            Id = userDTO.Id,
            UserName = userDTO.UserName,
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            MiddleName = userDTO.MiddleName,
            PhoneNumber = userDTO.PhoneNumber,
            Location = userDTO.Location,
            BirthDate = userDTO.BirthDate,
            Email = userDTO.Email
        };
    }
}
