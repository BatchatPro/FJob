using FJob.Domain;
using FJob.Repository.Models;
using FJob.Repository.Models.AccessReferences;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FJob.Repository.Configuration;

public class WorkerMap : BaseEntityConfiguration<Worker>
{
    public override void Configure(EntityTypeBuilder<Worker> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Category).WithMany(x => x.Workers);
        builder.HasOne(x => x.District).WithMany(x => x.Workers);
    }
}