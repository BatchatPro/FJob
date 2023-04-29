using FJob.Domain;

namespace FJob.Repository.Models;

public class Job: BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string MinSalary { get; set; }
    public string MaxSalary { get; set; }
    public DateTime Deadline { get; set; }
    public string Demand { get; set; }
    public string Benefit { get; set; }
    public string Location { get; set; }
    public string ModeInfo { get; set; }
    public string Gender { get; set; }
    public string WorkingTime { get; set; }
    public string CallTime { get; set; }
    public string Status { get; set; }

    public int DistrictId { get; set; }
    public int CategoryId { get; set; }
    public District District { get; set; }
    public Category Category { get; set; }
}

