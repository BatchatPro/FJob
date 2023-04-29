using FJob.Domain;
using FJob.Repository.Models;
using FJob.Repository.Models.AccessReferences;
using Microsoft.EntityFrameworkCore;

namespace FJob.Repository;

public class FJobDbContext : BoundedDbContext<FJobDbContext>
{
    public FJobDbContext(DbContextOptions<FJobDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Database.Migrate();
    }

    // DbSets
    public DbSet<UserReference> UserReferences { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserReference>()
            .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}