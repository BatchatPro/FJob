using FJob.Access.DTOs;
using FJob.Access.Models;
using System.Text.Json;

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
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            PhoneNumber = user.PhoneNumber,
            Location = user.Location,
            BirthDate = user.BirthDate,
            Gender = user.Gender
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
            Email = userDTO.Email,
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            MiddleName = userDTO.MiddleName,
            PhoneNumber = userDTO.PhoneNumber,
            Location = userDTO.Location,
            BirthDate = userDTO.BirthDate,
            Gender = userDTO.Gender
        };
    }

    public static IEnumerable<UserDTO> ConvertToDTO(this IEnumerable<UserDTO> users) =>
        users.Select(user => new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            PhoneNumber = user.PhoneNumber,
            Location = user.Location,
            BirthDate = user.BirthDate,
            Gender = user.Gender
        });

    public static IEnumerable<User> ConvertToDTO(this IEnumerable<User> users) =>
        users.Select(user => new User()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            PhoneNumber = user.PhoneNumber,
            Location = user.Location,
            BirthDate = user.BirthDate,
            Gender = user.Gender
        });


    public static RoleDTO ConvertToDTO(this Role role)
    {
        if (role == null)
            return null;
        return new RoleDTO()
        {
            Name = role.Name,
        };
    }

}
