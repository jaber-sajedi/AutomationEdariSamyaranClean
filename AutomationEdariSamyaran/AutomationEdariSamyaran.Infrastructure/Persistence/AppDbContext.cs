using AutomationEdariSamyaran.Application.Interfaces;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Entities.Workflow;
using Microsoft.EntityFrameworkCore;


namespace AutomationEdariSamyaran.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<WorkflowInstance> WorkflowInstances { get; set; }
        public DbSet<WorkflowInstanceStep> WorkflowInstanceSteps { get; set; }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Letter> Letters { get; set; }
        public DbSet<LetterAttachment> LetterAttachments { get; set; }
        public DbSet<LetterNumberSequence> LetterNumberSequences { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}










// Seed Data
//modelBuilder.Entity<ApplicationSetting>().HasData(
//    new ApplicationSetting
//    {
//        Id = 1,
//        KeyEnum = ApplicationSettingKey.BackupPath,
//        Value = "C:\\Backup"
//    },
//    new ApplicationSetting
//    {
//        Id = 2,
//        KeyEnum = ApplicationSettingKey.ApplicationName,
//        Value = "اتوماسیون اداری سامیاران"
//    }
//);