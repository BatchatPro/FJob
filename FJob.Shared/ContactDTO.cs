using System.ComponentModel.DataAnnotations;

namespace FJob.Shared;

public class ContactDTO
{
    public int Id { get; set; }
    [Required]
    public string Theme { get; set; }
    [Required]
    public string MoreInfo { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}