using System.ComponentModel.DataAnnotations;

namespace FJob.Shared;

public class RegionDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; }
}
