using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StoreDailyEntryConfiguration : IEntityTypeConfiguration<StoreDailyEntry>
{
    public void Configure(EntityTypeBuilder<StoreDailyEntry> builder)
    {
        builder.ToTable("StoreDailyEntries");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.TerminalAchieved).HasPrecision(18, 2);

        builder.HasIndex(e => new { e.StoreId, e.Date }).IsUnique();

        builder.HasOne(e => e.Store)
            .WithMany(s => s.DailyEntries)
            .HasForeignKey(e => e.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
