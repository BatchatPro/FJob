using NullGuard;
using System.ComponentModel.DataAnnotations;

namespace FJob.Access.DTOs;

public class UserDTO
{
    public string Id { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string MiddleName { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public string Location { get; set; }

    [Required(ErrorMessage = "This Field Requider!")]
    public DateTime BirthDate { get; set; }

    [AllowNull]
    public string? Email { get; set; }
}
