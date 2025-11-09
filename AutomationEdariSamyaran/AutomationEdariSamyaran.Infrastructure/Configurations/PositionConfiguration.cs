using AutomationEdariSamyaran.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationEdariSamyaran.Infrastructure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // نام جدول
            builder.ToTable("Positions");

            // کلید اصلی
            builder.HasKey(p => p.Id);

            // تنظیم ستون‌ها (اختیاری ولی توصیه می‌شود)
            builder.Property(p => p.Name)
                   .IsRequired()          // ستون اجباری
                   .HasMaxLength(100);    // طول حداکثر

            // می‌توانید مقادیر پیش‌فرض یا دیگر محدودیت‌ها هم اضافه کنید
        }
    }
}
