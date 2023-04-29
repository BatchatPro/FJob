using FJob.Domain;

namespace FJob.Repository.Models;

public class Job: BaseJob
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Benefit { get; set; }
    public string Location { get; set; }
    public string Gender { get; set; }

    public int DistrictId { get; set; }
    public int CategoryId { get; set; }
    public District District { get; set; }
    public Category Category { get; set; }
}

