using FJob.Domain;

namespace FJob.Repository.Models;

public class Category: BaseEntity
{
    public string Title{ get; set; }
    public string Description { get; set; }
}