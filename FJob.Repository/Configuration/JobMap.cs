using FJob.Domain;
using FJob.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FJob.Repository.Configuration;

public class JobMap : BaseEntityConfiguration<Job>
{
    public override void Configure(EntityTypeBuilder<Job> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Category).WithMany(x => x.Jobs);
        builder.HasOne(x => x.District).WithMany(x => x.Jobs);
    }

}
