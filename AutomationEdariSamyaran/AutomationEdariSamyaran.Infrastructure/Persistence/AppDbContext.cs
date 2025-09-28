using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Entities.YourNamespace;
using AutomationEdariSamyaran.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AutomationEdariSamyaran.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
         public DbSet<Greatadvice> Greatadvices => Set<Greatadvice>();
        public DbSet<letterSubject> LetterSubjects => Set<letterSubject>();
        public DbSet<Units> Units => Set<Units>();
        public DbSet<State> States => Set<State>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Personal> Personals => Set<Personal>();
        public DbSet<CellarKoll> CellarKolls => Set<CellarKoll>();
        public DbSet<CellarMoein> CellarMoeins => Set<CellarMoein>();
        public DbSet<CellarTafzilli> CellarTafzillis => Set<CellarTafzilli>();
        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<OrganizationalRank> OrganizationalRanks => Set<OrganizationalRank>();
        public DbSet<OrganizationalChart> OrganizationalCharts => Set<OrganizationalChart>();
        public DbSet<Unitsmeasurement> UnitsMeasurements => Set<Unitsmeasurement>();
        //public DbSet<GoodsImportation> GoodsImportations => Set<GoodsImportation>();
        //public DbSet<Publicmessages> Publicmessages => Set<Publicmessages>();
        //public DbSet<PublicMessagePermission> PublicMessagePermissions => Set<PublicMessagePermission>();
        //public DbSet<Requestleave> Requestleaves => Set<Requestleave>();
        //public DbSet<RequestLeavePermission> RequestleavePermissions => Set<RequestLeavePermission>();
        //public DbSet<RankPermission> RankPermissions => Set<RankPermission>();
        //public DbSet<GoodsRequest> GoodsRequests => Set<GoodsRequest>();
        //public DbSet<GoodsDeparture> GoodsDepartures => Set<GoodsDeparture>();
         public DbSet<PhoneBook> PhoneBooks => Set<PhoneBook>();
        public DbSet<DailyReminderTask> DailyReminderTasks => Set<DailyReminderTask>();
        public DbSet<letterDraft> Draftletters => Set<letterDraft>();
        public DbSet<LetterRecepiant> LetterRecepiants => Set<LetterRecepiant>();
        public DbSet<Letters> Letters => Set<Letters>();


        public DbSet<ArchivesKoll> ArchivesKolls => Set<ArchivesKoll>();
        public DbSet<ArchivesMoein> ArchivesMoeins => Set<ArchivesMoein>();
        public DbSet<ArchivesTafzilli> ArchivesTafzillis => Set<ArchivesTafzilli>();
        public DbSet<ApplicationSetting> ApplicationSettings => Set<ApplicationSetting>();
         public DbSet<UserPermission> UserPermissions => Set<UserPermission>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // یک به چند: Koll -> Moein
            modelBuilder.Entity<ArchivesMoein>()
                .HasOne(c=>c.Koll)
                .WithMany(k=>k.Moeins)
                .HasForeignKey(m=>m.IdKoll)
                .OnDelete(DeleteBehavior.Cascade);

            // یک به چند: Moein -> Tafzilli
            modelBuilder.Entity<ArchivesTafzilli>()
                 .HasOne(t=>t.Moein) .WithMany(m=>m.Tafzillis)
                 .HasForeignKey(m=>m.IdMoein)
                 .OnDelete(DeleteBehavior.Cascade);

            // ارتباط اختیاری: Koll -> Tafzilli مستقیم (اگر نیاز دارید)
            modelBuilder.Entity<ArchivesTafzilli>()
                .HasOne(t => t.Koll)
                .WithMany(k => k.Tafzillis)
                .HasForeignKey(t => t.IdKoll)
                .OnDelete(DeleteBehavior.Restrict);

            // یک به چند: State -> City
            modelBuilder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.Id_State)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // یک به چند: OrganizationalRank -> OrganizationalChart
            modelBuilder.Entity<OrganizationalChart>()
                .HasOne(c => c.Rank)
                .WithMany(r => r.Charts)
                .HasForeignKey(c => c.IdOrgan_Rank)
                .OnDelete(DeleteBehavior.Restrict);

            // Self-reference: Father -> Children
            modelBuilder.Entity<OrganizationalChart>()
                .HasOne(c => c.Father)
                .WithMany(f => f.Children)
                .HasForeignKey(c => c.IdFather)
                .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف تصادفی سلسله‌مراتبی

            // یک به چند: LetterRecepiant -> Letters
            modelBuilder.Entity<Letters>()
                .HasOne(l => l.Recepiant)
                .WithMany(r => r.Letters)
                .HasForeignKey(l => l.IdReceiveLetters)
                .OnDelete(DeleteBehavior.Restrict);

            #region  Cellar

            // یک به چند: Koll -> Moein
            modelBuilder.Entity<CellarMoein>()
                .HasOne(m => m.Koll)
                .WithMany(k => k.Moeins)
                .HasForeignKey(m => m.IdKoll)
                .OnDelete(DeleteBehavior.Cascade);

            // یک به چند: Moein -> Tafzilli
            modelBuilder.Entity<CellarTafzilli>()
                .HasOne(t => t.Moein)
                .WithMany(m => m.Tafzillis)
                .HasForeignKey(t => t.IdMoein)
                .OnDelete(DeleteBehavior.Cascade);

            // یک به چند: Koll -> Tafzilli مستقیم (اختیاری)
            modelBuilder.Entity<CellarTafzilli>()
                .HasOne(t => t.Koll)
                .WithMany(k => k.Tafzillis)
                .HasForeignKey(t => t.IdKoll)
                .OnDelete(DeleteBehavior.Restrict);

            // یک به چند: Unitsmeasurement -> Tafzilli
            modelBuilder.Entity<CellarTafzilli>()
                .HasOne(t => t.UnitsMeasurement)
                .WithMany(u => u.Tafzillis)
                .HasForeignKey(t => t.IdUnitsMeasurement)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Personal
            // ارتباط Personal -> State
            modelBuilder.Entity<Personal>()
                .HasOne(p => p.State)
                .WithMany()
                .HasForeignKey(p => p.IdState)
                .OnDelete(DeleteBehavior.Restrict);

            // ارتباط Personal -> City
            modelBuilder.Entity<Personal>()
                .HasOne(p => p.City)
                .WithMany()
                .HasForeignKey(p => p.IdCity)
                .OnDelete(DeleteBehavior.Restrict);

            // ارتباط Personal -> Units
            modelBuilder.Entity<Personal>()
                .HasOne(p => p.Units)
                .WithMany()
                .HasForeignKey(p => p.IdUnit)
                .OnDelete(DeleteBehavior.Restrict);

            // ارتباط Personal -> OrganizationalRank
            modelBuilder.Entity<Personal>()
                .HasOne(p => p.organizationalRank)
                .WithMany()
                .HasForeignKey(p => p.IdOrganRanks)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion


            modelBuilder.Entity<ApplicationSetting>().HasData(
             new ApplicationSetting
             {
                 Id = 1,
                 KeyEnum = ApplicationSettingKey.BackupPath,
                 Value = "C:\\Backup"
             },
             new ApplicationSetting
             {
                 Id = 2,
                 KeyEnum = ApplicationSettingKey.ApplicationName,
                 Value = "اتوماسیون اداری سامیاران"
             }
         );
        }
    }
}