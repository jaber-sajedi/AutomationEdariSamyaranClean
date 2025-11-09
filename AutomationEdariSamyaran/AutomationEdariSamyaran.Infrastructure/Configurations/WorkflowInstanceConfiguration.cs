using AutomationEdariSamyaran.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomationEdariSamyaran.Infrastructure.Configurations
{
    public class WorkflowInstanceConfiguration : IEntityTypeConfiguration<WorkflowInstance>
    {
        public void Configure(EntityTypeBuilder<WorkflowInstance> builder)
        {
            builder.ToTable("WorkflowInstances");
            builder.HasKey(wi => wi.Id);

            builder.HasOne(wi => wi.Workflow)
                   .WithMany()
                   .HasForeignKey(wi => wi.WorkflowId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(wi => wi.Personal)
                   .WithMany()
                   .HasForeignKey(wi => wi.PersonalId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
