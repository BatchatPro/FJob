using System.ComponentModel.DataAnnotations;

namespace FJob.Shared;

public class DistrictDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public int RegionId { get; set; }
}
