using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StoreMonthlyTargetConfiguration : IEntityTypeConfiguration<StoreMonthlyTarget>
{
    public void Configure(EntityTypeBuilder<StoreMonthlyTarget> builder)
    {
        builder.ToTable("StoreMonthlyTargets");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Terminal).HasPrecision(18, 2);

        builder.HasIndex(t => new { t.StoreId, t.Year, t.Month }).IsUnique();

        builder.HasOne(t => t.Store)
            .WithMany(s => s.MonthlyTargets)
            .HasForeignKey(t => t.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
