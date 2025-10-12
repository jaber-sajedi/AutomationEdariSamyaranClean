using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
   public class Personal
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!; // نام کامل

        public string? PersonalCode { get; set; } // کد پرسنلی

        public int? IdPosition { get; set; } = null!;

        public int? IdDepartment { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; } // آدرس کامل

        public string? BirthCity { get; set; } // شهر محل تولد

        public string? BirthProvince { get; set; } // استان محل تولد

        public DateTime? BirthDate { get; set; } // تاریخ تولد

        public string? NationalCode { get; set; } // کد ملی

        public string? InsuranceNumber { get; set; } // شماره بیمه

        public int NumberOfChildren { get; set; } = 0; // تعداد فرزند

        public string? EmergencyContactPhone { get; set; } // تلفن تماس اضطراری
        public string? BankAccountNumber { get; set; } // شماره حساب برای حقوق
        public string? BankName { get; set; } // نام بانک
        public DateTime? EmploymentStartDate { get; set; } // تاریخ شروع به کار
        public DateTime? EmploymentEndDate { get; set; } // تاریخ پایان خدمت (در صورت ترک سازمان)
        public bool IsActive { get; set; } = true; // فعال / غیرفعال
    }
}
 
