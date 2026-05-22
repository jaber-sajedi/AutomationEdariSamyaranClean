using AutomationEdariSamyaran.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{

    public class Personal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = null!; // نام کامل

        [MaxLength(50)]
        public string? PersonalCode { get; set; } // کد پرسنلی

        [MaxLength(100)]
        public int? IdPosition { get; set; } = null!;
        public Position? Position { get; set; } = null!;

        [MaxLength(100)]
        public int? IdDepartment { get; set; }
        public Department? Department { get; set; } = null!; // واحد / دپارتمان

        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; } // آدرس کامل

        [MaxLength(100)]
        public string? BirthCity { get; set; } // شهر محل تولد

        [MaxLength(100)]
        public string? BirthProvince { get; set; } // استان محل تولد

        public DateTime? BirthDate { get; set; } // تاریخ تولد

        [MaxLength(20)]
        public string? NationalCode { get; set; } // کد ملی

        [MaxLength(20)]
        public string? InsuranceNumber { get; set; } // شماره بیمه

        [MaxLength(50)]
        public MaritalStatus? MaritalStatus { get; set; } // وضعیت تاهل: مجرد، متاهل

        public int NumberOfChildren { get; set; } = 0; // تعداد فرزند

        [MaxLength(20)]
        public string? EmergencyContactPhone { get; set; } // تلفن تماس اضطراری

        [MaxLength(150)]
        public string? BankAccountNumber { get; set; } // شماره حساب برای حقوق

        [MaxLength(150)]
        public string? BankName { get; set; } // نام بانک

        public DateTime? EmploymentStartDate { get; set; } // تاریخ شروع به کار

        public DateTime? EmploymentEndDate { get; set; } // تاریخ پایان خدمت (در صورت ترک سازمان)

        public bool IsActive { get; set; } = true; // فعال / غیرفعال

        public int? IdSection { get; set; } = null!;
        public Section? Section { get; set; } = null!;
    }
}

