using FJob.Domain;

namespace FJob.Repository.Models;

public class Worker: BaseJob
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
