using FJob.Domain;

namespace FJob.Repository.Models;

public class Category: BaseEntity
{
    public string Title{ get; set; }
    public string Description { get; set; }

    public ICollection<Worker> Workers { get; internal set; }
    public ICollection<Job> Jobs { get; internal set; }
}