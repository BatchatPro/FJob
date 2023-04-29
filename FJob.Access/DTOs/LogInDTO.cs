using System.ComponentModel.DataAnnotations;

namespace FJob.Access.DTOs;

public class LogInDTO
{
    [Required(ErrorMessage = "This Poly is Required.")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "This Poly is Required.")]
    public string Password { get; set; }
}

