using FJob.Domain;
using FJob.Repository.Models.AccessReferences;

namespace FJob.Repository.Models;

public class UserSocialLink : BaseEntity
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    public int SocialLinkId { get; set; }
    public UserReference UserReference { get; set; }
    public SocialLink SocialLink { get; set; }
}