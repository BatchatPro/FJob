using FJob.Domain;

namespace FJob.Repository.Models;

public class District:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int RegionId { get; set; } 
    public Region Region { get; set; }
}