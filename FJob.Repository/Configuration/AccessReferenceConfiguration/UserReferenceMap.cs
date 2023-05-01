using FJob.Domain;
using FJob.Repository.Models.AccessReferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FJob.Repository.Configuration.AccessReferenceConfiguration;

public class UserReferenceMap : BaseAccessEntityTypeConfiguration<UserReference> 
{
    public override void Configure(EntityTypeBuilder<UserReference> builder)
    {
        base.Configure(builder);
        builder.ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
    }
}
