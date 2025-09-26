using AutomationEdariSamyaran.Domain.Entities;
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

        public virtual DbSet<TBL_User> TBL_User { get; set; }
        public virtual DbSet<TBL_Great_advice> TBL_Great_advice { get; set; }
        public virtual DbSet<TBL_Company_information> TBL_Company_information { get; set; }
        public virtual DbSet<TBL_letter_Subject> TBL_Letter_Subjects { get; set; }
        public virtual DbSet<TBL_Units> TBL_Units { get; set; }
        public virtual DbSet<TBL_BackupPath> TBL_BackupPaths { get; set; }
        public virtual DbSet<TBL_Gender> TBL_Genders { get; set; }
        public virtual DbSet<TBL_State> TBL_States { get; set; }
        public virtual DbSet<TBL_Cities> TBL_Cities { get; set; }
        public virtual DbSet<TBL_Degree_Education> TBL_Degree_Educations { get; set; }
        public virtual DbSet<TBL_Marital_Status> TBL_Marital_Statuses { get; set; }
        public virtual DbSet<TBL_Personal> TBL_Personals { get; set; }
        public virtual DbSet<TBL_Cellar_Koll> TBL_Cellar_Kolls { get; set; }
        public virtual DbSet<TBL_Cellar_Moein> TBL_Cellar_Moeins { get; set; }
        public virtual DbSet<TBL_Cellar_Tafzilli> TBL_Cellar_Tafzillis { get; set; }
        public virtual DbSet<TBL_Seller> TBL_Sellers { get; set; }
        public virtual DbSet<TBL_Organizational_Rank> TBL_Organizational_Ranks { get; set; }
        public virtual DbSet<TBL_Organizational_Chart> TBL_Organizational_Charts { get; set; }
        public virtual DbSet<TBL_Units_measurement> TBL_Units_Measurement { get; set; }
        public virtual DbSet<TBL_Goods_Importation> TBL_Goods_Importation { get; set; }
        public virtual DbSet<TBL_Public_messages> TBL_Public_messages { get; set; }
        public virtual DbSet<TBL_Public_Message_Permission> TBL_Public_Message_Permission { get; set; }
        public virtual DbSet<TBL_Request_leave> TBL_Request_leave { get; set; }
        public virtual DbSet<TBL_Request_leave_Permission> TBL_Request_leave_Permission { get; set; }
        public virtual DbSet<TBL_Rank_Permission> TBL_Rank_Permission { get; set; }
        public virtual DbSet<TBL_Goods_Request> TBL_Goods_Requests { get; set; }
        public virtual DbSet<TBL_Goods_Departure> TblGoodsDepartures { get; set; }
        public virtual DbSet<TBL_PhoneBook> TBL_PhoneBooks { get; set; }
        public virtual DbSet<TBL_Daily_Reminder_Task> Tbl_DailyReminderTasks { get; set; }
        public virtual DbSet<TBL_letter_Draft> TBL_Draft_letters { get; set; }
        public virtual DbSet<TBL_Letter_Recepiant> TBL_Letter_Recepiants { get; set; }
        public virtual DbSet<TBL_Letters> TBL_Letterss { get; set; }
        public virtual DbSet<TBL_Archives_Koll> TBL_Archives_Kolls { get; set; }
        public virtual DbSet<TBL_Archives_Moein> TBL_Archives_Moeins { get; set; }
        public virtual DbSet<TBL_Archives_Tafzilli> TBL_Archives_Tafzillis { get; set; }
        public virtual DbSet<TBL_Application_Setting> TBL_ApplicationSettings { get; set; }
        public virtual DbSet<TBL_User_Permission> TBL_User_Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           
        }
    }
}
