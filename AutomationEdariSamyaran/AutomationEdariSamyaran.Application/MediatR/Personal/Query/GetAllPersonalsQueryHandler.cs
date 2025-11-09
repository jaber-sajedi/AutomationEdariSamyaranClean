using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Personal.Query
{
    public class GetAllPersonalsQueryHandler : IRequestHandler<GetAllPersonalsQuery, List<PersonalDto>>
    {
        private readonly AppDbContext _context;

        public GetAllPersonalsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalDto>> Handle(GetAllPersonalsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Personals
                .Include(p => p.Position)
                .Include(p => p.Department)
                .Select(p => new PersonalDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    PersonalCode = p.PersonalCode,
                    IdPosition = p.IdPosition,
                    PositionName = p.Position != null ? p.Position.Name : null,
                    IdDepartment = p.IdDepartment,
                    DepartmentName = p.Department != null ? p.Department.Name : null,
                    Email = p.Email,
                    Phone = p.Phone,
                    Address = p.Address,
                    BirthCity = p.BirthCity,
                    BirthProvince = p.BirthProvince,
                    BirthDate = p.BirthDate,
                    NationalCode = p.NationalCode,
                    InsuranceNumber = p.InsuranceNumber,
                    MaritalStatus = p.MaritalStatus != null ? p.MaritalStatus.ToString() : null,
                    NumberOfChildren = p.NumberOfChildren,
                    EmergencyContactPhone = p.EmergencyContactPhone,
                    BankAccountNumber = p.BankAccountNumber,
                    BankName = p.BankName,
                    EmploymentStartDate = p.EmploymentStartDate,
                    EmploymentEndDate = p.EmploymentEndDate,
                    IsActive = p.IsActive
                })
                .ToListAsync(cancellationToken);
        }
    }
}
