using Microsoft.EntityFrameworkCore;

namespace FJob.Domain;

public class BoundedDbContext<TContext> : DbContext where TContext : DbContext
{
    public BoundedDbContext()
    {
    }
    public BoundedDbContext(DbContextOptions<TContext> options) : base(options)
    {
        Database.Migrate();
    }
}
