using AutomationEdariSamyaran.WPF.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class CreatePersonalCommand
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string? FullName { get; set; }

        [Display(Name = "کد پرسنلی")]
        public string? PersonalCode { get; set; }

        [Display(Name = "شناسه سمت شغلی")]
        public int? IdPosition { get; set; }

        [Display(Name = "شناسه دپارتمان")]
        public int? IdDepartment { get; set; }

        [Display(Name = "ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "شماره تلفن")]
        public string? Phone { get; set; }

        [Display(Name = "آدرس")]
        public string? Address { get; set; }

        [Display(Name = "شهر محل تولد")]
        public string? BirthCity { get; set; }

        [Display(Name = "استان محل تولد")]
        public string? BirthProvince { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "کد ملی")]
        public string? NationalCode { get; set; }

        [Display(Name = "شماره بیمه")]
        public string? InsuranceNumber { get; set; }

        [Display(Name = "وضعیت تأهل")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Display(Name = "تعداد فرزندان")]
        public int? NumberOfChildren { get; set; }

        [Display(Name = "شماره تماس اضطراری")]
        public string? EmergencyContactPhone { get; set; }

        [Display(Name = "شماره حساب بانکی")]
        public string? BankAccountNumber { get; set; }

        [Display(Name = "نام بانک")]
        public string? BankName { get; set; }

        [Display(Name = "تاریخ شروع استخدام")]
        public DateTime? EmploymentStartDate { get; set; }

        [Display(Name = "تاریخ پایان استخدام")]
        public DateTime? EmploymentEndDate { get; set; }

        [Display(Name = "وضعیت فعال بودن")]
        public bool? IsActive { get; set; }             // فعال بودن پرسنل
    }
}
