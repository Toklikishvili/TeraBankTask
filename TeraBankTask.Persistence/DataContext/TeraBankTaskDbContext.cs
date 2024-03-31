using Microsoft.EntityFrameworkCore;
using TeraBankTask.Domain.Entities;

namespace TeraBankTask.Persistence.DataContext;

public class TeraBankTaskDbContext : DbContext
{
    public TeraBankTaskDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction>  Transactions { get; set; }
}
