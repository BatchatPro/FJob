using FJob.Domain;

namespace FJob.Repository.Models;

public class Contact: BaseEntity
{
    public string Theme { get; set; }
    public string MoreInfo { get; set; }
    public string PhoneNumber { get; set; }
}
