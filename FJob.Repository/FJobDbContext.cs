using FJob.Domain;
using FJob.Repository.Configuration;
using FJob.Repository.Configuration.AccessReferenceConfiguration;
using FJob.Repository.Models;
using FJob.Repository.Models.AccessReferences;
using Microsoft.EntityFrameworkCore;

namespace FJob.Repository;

public class FJobDbContext : BoundedDbContext<FJobDbContext>
{
    public DbSet<UserReference> UserReferences { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Category> Categories { get; set; }

    public FJobDbContext(DbContextOptions<FJobDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserReferenceMap());
        modelBuilder.ApplyConfiguration(new WorkerMap());
        modelBuilder.ApplyConfiguration(new JobMap());
        modelBuilder.ApplyConfiguration(new DistrictMap());
        modelBuilder.ApplyConfiguration(new UserSocialLinkMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}