using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
{
      public DbSet<User> Users { get; set; }
      public DbSet<RefreshToken> RefreshTokens { get; set; }
      public DbSet<StoreDailyEntry> StoreDailyEntries { get; set; }
      public DbSet<StoreMonthlyTarget> StoreMonthlyTargets { get; set; }




      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
      }
}
