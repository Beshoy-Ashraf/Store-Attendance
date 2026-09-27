using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttendanceSettingsConfiguration : IEntityTypeConfiguration<AttendanceSettings>
{
      public void Configure(EntityTypeBuilder<AttendanceSettings> builder)
      {
            builder.ToTable("AttendanceSettings");
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.StoreId).IsUnique();
            builder.HasQueryFilter(a => a.Store == null || a.Store.DeleteDate == null);
            builder.Property(a => a.LateGraceMinutes).HasDefaultValue(0);

            builder.HasIndex(a => a.StoreId).IsUnique();
      }
}