using FJob.Domain;
using FJob.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FJob.Repository.Configuration;

public class UserSocialLinkMap : BaseEntityConfiguration<UserSocialLink> 
{
    public override void Configure(EntityTypeBuilder<UserSocialLink> builder)
    {
        base.Configure(builder);

        builder.HasKey(bc => new { bc.UserId, bc.SocialLinkId });

        builder.HasOne(bc => bc.UserReference)
            .WithMany(b => b.UserSocialLinks)
            .HasForeignKey(bc => bc.UserId);

        builder.HasOne(bc => bc.SocialLink)
            .WithMany(b => b.UserSocialLinks)
            .HasForeignKey(bc => bc.SocialLinkId);
    }
}
