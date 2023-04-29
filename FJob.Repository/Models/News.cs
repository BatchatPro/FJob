using FJob.Domain;

namespace FJob.Repository.Models;

public class News : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ViewsCount { get; set; }
}
