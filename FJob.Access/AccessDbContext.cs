using FJob.Access.Models;
using FJob.Access.Models.RepositoryReferences;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FJob.Access;

public class AccessDbContext : IdentityDbContext<User, Role, string>
{
    public AccessDbContext(DbContextOptions<AccessDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Database.Migrate();
    }

    //// DbSets
    //public DbSet<DistrictReference> DistrictReferences { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<DistrictReference>()
    //        .ToTable("District", t => t.ExcludeFromMigrations());
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //}
}