using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FJob.Domain;

public abstract class BaseAccessEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : IdentityUser
{
    public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
    {
    }
}
