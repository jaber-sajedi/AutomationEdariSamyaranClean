using AutomationEdariSamyaran.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationEdariSamyaran.Infrastructure.Configurations
{
    public class WorkflowStepConfiguration : IEntityTypeConfiguration<WorkflowStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowStep> builder)
        {
            builder.ToTable("WorkflowSteps");
            builder.HasKey(ws => ws.Id);

            builder.Property(ws => ws.Name).IsRequired().HasMaxLength(200);
            builder.HasOne(ws => ws.Workflow)
                   .WithMany()
                   .HasForeignKey(ws => ws.WorkflowId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ws => ws.Role)
                   .WithMany()
                   .HasForeignKey(ws => ws.RoleId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
