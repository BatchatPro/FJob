using FJob.Domain;

namespace FJob.Access.Models.RepositoryReferences;

public class DistrictReference:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

}
