using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Personal.Command
{
     
        public record CreatePersonalCommand(
            string? FullName,
            string? PersonalCode,
            int? IdPosition,
            int? IdDepartment,
            string? Email,
            string? Phone,
            string? Address,
            string? BirthCity,
            string? BirthProvince,
            DateTime? BirthDate,
            string? NationalCode,
            string? InsuranceNumber,
            string? MaritalStatus,
            int NumberOfChildren,
            string? EmergencyContactPhone,
            string? BankAccountNumber,
            string? BankName,
            DateTime? EmploymentStartDate,
            DateTime? EmploymentEndDate,
            bool IsActive
        ) : IRequest<int>; // بازگشت Id
    }
 
