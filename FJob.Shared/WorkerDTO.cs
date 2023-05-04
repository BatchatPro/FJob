using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FJob.Shared;

public class WorkerDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Minimum Salery is required")]
    public string MinSalary { get; set; }
    [Required(ErrorMessage = "Maximum is required")]
    public string MaxSalary { get; set; }
    [Required(ErrorMessage = "Deadline is required")]
    public DateTime Deadline { get; set; }
    [Required(ErrorMessage = "Create Date is required")]
    public DateTime CreateDate { get; set; }
    [Required(ErrorMessage = "Update Date is required")]
    public DateTime UpdateDate { get; set; }
    [Required(ErrorMessage = "Demand is required")]
    public string Demand { get; set; }
    [Required(ErrorMessage = "More Info is required")]
    public string MoreInfo { get; set; }
    [Required(ErrorMessage = "Working Time is required")]
    public string WorkingTime { get; set; }
    [Required(ErrorMessage = "Call Time is required")]
    public string CallTime { get; set; }
    [Required(ErrorMessage = "Status is required")]
    public string Status { get; set; }
    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }
    public int Age { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    [AllowNull]
    public string? CreatedBy { get; set; }
    [AllowNull]
    public string? UpdatedBy { get; set; }
    [AllowNull]
    public int DistrictId { get; set; }
    [AllowNull]
    public int CategoryId { get; set; }

}
