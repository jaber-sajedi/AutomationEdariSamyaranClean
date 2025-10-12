using AutomationEdariSamyaran.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AutomationEdariSamyaran.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

       
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Workflow> Workflows => Set<Workflow>();
        public DbSet<WorkflowStep> WorkflowSteps => Set<WorkflowStep>();
        public DbSet<WorkflowInstance> WorkflowInstances => Set<WorkflowInstance>();
        public DbSet<WorkflowInstanceStep> WorkflowInstanceSteps => Set<WorkflowInstanceStep>();
        public DbSet<Personal> Personals => Set<Personal>();
        public DbSet<Department>  Departments => Set<Department>();
        public DbSet<Position>  Positions => Set<Position>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

         
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


        }
    }
   
}
