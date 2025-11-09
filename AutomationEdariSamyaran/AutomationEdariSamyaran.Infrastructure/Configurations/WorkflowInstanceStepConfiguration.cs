using AutomationEdariSamyaran.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationEdariSamyaran.Infrastructure.Configurations
{
    public class WorkflowInstanceStepConfiguration : IEntityTypeConfiguration<WorkflowInstanceStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowInstanceStep> builder)
        {
            builder.ToTable("WorkflowInstanceSteps");
            builder.HasKey(wis => wis.Id);

            builder.HasOne(wis => wis.WorkflowInstance)
                   .WithMany()
                   .HasForeignKey(wis => wis.WorkflowInstanceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wis => wis.WorkflowStep)
                   .WithMany()
                   .HasForeignKey(wis => wis.WorkflowStepId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(wis => wis.AssignedTo)
                   .WithMany()
                   .HasForeignKey(wis => wis.AssignedToId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
