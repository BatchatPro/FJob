namespace FJob.Access.Models.RepositoryReferences;

public class DistrictReference
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    public ICollection<User> Users { get; set; }

}
