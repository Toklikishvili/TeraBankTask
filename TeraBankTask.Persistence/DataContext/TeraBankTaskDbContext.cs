using Microsoft.EntityFrameworkCore;
using TeraBankTask.Domain.Entities;
using TeraBankTask.Persistence.Configurations;

namespace TeraBankTask.Persistence.DataContext;

public class TeraBankTaskDbContext : DbContext
{
    public TeraBankTaskDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction>  Transactions { get; set; }
}
