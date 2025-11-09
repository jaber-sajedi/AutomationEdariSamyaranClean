
using AutomationEdariSamyaran.Application.Exceptions;
using AutomationEdariSamyaran.Domain.Enums;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Personal.Command
{
    public class CreatePersonalCommandHandler : IRequestHandler<CreatePersonalCommand, int>
    {
        private readonly AppDbContext _context;

        public CreatePersonalCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonalCommand request, CancellationToken cancellationToken)
        {

            var existingPersonalByName =
                await _context.Personals.FirstOrDefaultAsync(c => c.FullName == request.FullName);

            if (existingPersonalByName != null)
            {
                throw AppException.Create(
                               $"پرسنلی با نام '{request.FullName}' از قبل وجود دارد.",
                               HttpStatusCode.BadRequest,
                               "Personal_DUPLICATE");
            }
            var existingPersonalByCode =
                await _context.Personals.FirstOrDefaultAsync(c => c.FullName == request.FullName);
            if (existingPersonalByName != null)
            {
                throw AppException.Create(
                    $"پرسنلی با کد ملی '{request.NationalCode}' از قبل وجود دارد.",
                    HttpStatusCode.BadRequest,
                    "Personal_DUPLICATE");
            }



            var personal = new Domain.Entities.Personal
            {
                FullName = request.FullName,
                PersonalCode = request.PersonalCode,
                IdPosition = request.IdPosition,
                IdDepartment = request.IdDepartment,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                BirthCity = request.BirthCity,
                BirthProvince = request.BirthProvince,
                BirthDate = request.BirthDate,
                NationalCode = request.NationalCode,
                InsuranceNumber = request.InsuranceNumber,
                MaritalStatus = request.MaritalStatus != null ? Enum.Parse<MaritalStatus>(request.MaritalStatus) : null,
                NumberOfChildren = request.NumberOfChildren,
                EmergencyContactPhone = request.EmergencyContactPhone,
                BankAccountNumber = request.BankAccountNumber,
                BankName = request.BankName,
                EmploymentStartDate = request.EmploymentStartDate,
                EmploymentEndDate = request.EmploymentEndDate,
                IsActive = request.IsActive
            };

            _context.Personals.Add(personal);
            await _context.SaveChangesAsync(cancellationToken);
            return personal.Id;
        }
    }
}
