using FJob.Domain;

namespace FJob.Repository.Models;

public class Category: BaseEntity
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public string Description { get; set; }
}