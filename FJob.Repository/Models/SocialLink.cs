using FJob.Domain;

namespace FJob.Repository.Models;

public class SocialLink : BaseEntity
{
    public string Name { get; set; }
    public string Url { get; set; }


    public ICollection<UserSocialLink> UserSocialLinks { get; set; }
}
