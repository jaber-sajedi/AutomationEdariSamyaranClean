using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.DTOs
{
    public class PersonalDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? PersonalCode { get; set; }
        public int? IdPosition { get; set; }
        public string? PositionName { get; set; }
        public int? IdDepartment { get; set; }
        public string? DepartmentName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? BirthCity { get; set; }
        public string? BirthProvince { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? NationalCode { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? MaritalStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public DateTime? EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
