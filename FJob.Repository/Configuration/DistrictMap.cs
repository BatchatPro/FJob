using FJob.Domain;
using FJob.Repository.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FJob.Repository.Configuration;

public class DistrictMap :  BaseEntityConfiguration<District>
{
    public override void Configure(EntityTypeBuilder<District> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Region).WithMany(x => x.Districts);
    }

}
