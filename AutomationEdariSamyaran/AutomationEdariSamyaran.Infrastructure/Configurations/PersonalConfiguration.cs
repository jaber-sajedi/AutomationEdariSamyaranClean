using AutomationEdariSamyaran.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationEdariSamyaran.Infrastructure.Persistence.Configuration
{
    public class PersonalConfiguration : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            // نام جدول در دیتابیس
            builder.ToTable("Personals");

            // کلید اصلی
            builder.HasKey(p => p.Id);

            // FullName: Required و حداکثر طول 200
            builder.Property(p => p.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            // PersonalCode: Optional و طول 50
            builder.Property(p => p.PersonalCode)
                   .HasMaxLength(50);

            // Position
            builder.Property(p => p.IdPosition);
            builder.HasOne(p => p.Position)
                   .WithMany()
                   .HasForeignKey(p => p.IdPosition)
                   .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف Cascade

            // Department
            builder.Property(p => p.IdDepartment);
            builder.HasOne(p => p.Department)
                   .WithMany()
                   .HasForeignKey(p => p.IdDepartment)
                   .OnDelete(DeleteBehavior.Restrict);

            // Email: Optional و طول 150
            builder.Property(p => p.Email)
                   .HasMaxLength(150);

            // Phone: Optional و طول 20
            builder.Property(p => p.Phone)
                   .HasMaxLength(20);

            // Address: Optional و طول 200
            builder.Property(p => p.Address)
                   .HasMaxLength(200);

            // BirthCity و BirthProvince
            builder.Property(p => p.BirthCity)
                   .HasMaxLength(100);
            builder.Property(p => p.BirthProvince)
                   .HasMaxLength(100);

            // BirthDate: Optional
            builder.Property(p => p.BirthDate);

            // NationalCode و InsuranceNumber
            builder.Property(p => p.NationalCode)
                   .HasMaxLength(20);
            builder.Property(p => p.InsuranceNumber)
                   .HasMaxLength(20);

            // MaritalStatus: Enum
            builder.Property(p => p.MaritalStatus)
                   .HasConversion<string>() // ذخیره به صورت متن
                   .HasMaxLength(50);

            // NumberOfChildren
            builder.Property(p => p.NumberOfChildren);

            // EmergencyContactPhone
            builder.Property(p => p.EmergencyContactPhone)
                   .HasMaxLength(20);

            // BankAccountNumber و BankName
            builder.Property(p => p.BankAccountNumber)
                   .HasMaxLength(150);
            builder.Property(p => p.BankName)
                   .HasMaxLength(150);

            // EmploymentStartDate و EmploymentEndDate
            builder.Property(p => p.EmploymentStartDate);
            builder.Property(p => p.EmploymentEndDate);

            // IsActive: Required, پیشفرض true
            builder.Property(p => p.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

            // Index روی PersonalCode
            builder.HasIndex(p => p.PersonalCode)
                   .IsUnique(false);
        }
    }
}
