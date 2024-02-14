using DinnerApp.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace DinnerApp.Infrastructure.Persistence;

public class DinnerDbContext(DbContextOptions<DinnerDbContext> options) : DbContext(options)
{
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
    } 
}
