﻿using NullGuard;
using System.ComponentModel.DataAnnotations;

namespace FJob.Access.DTOs;

public class RegistrationDTO
{
    [Required(ErrorMessage = "This Poly is Required.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    [StringLength(100, ErrorMessage = "Minimum Length = 8 !", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "It is not the same Password!")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public string MiddleName { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public DateTime BirthDate { get; set; }
    [Required(ErrorMessage = "This Poly is Required.")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "This Poly is Required.")]
    public string Gender { get; set; }

    [AllowNull]
    public string? Email { get; set; }

    [Required(ErrorMessage = "This Poly is Required.")]
    public string Role { get; set; }

    //[Required(ErrorMessage = "This Poly is Required.")]
    //public int DistrictId { get; set; }
}