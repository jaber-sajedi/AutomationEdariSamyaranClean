using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Queries;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Users.Handler
{
    public class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, UnitDto>
    {
        private readonly AppDbContext _context;

        public GetUnitByIdQueryHandler(AppDbContext context)
        {
            _context= context;
        }

        public async Task<UnitDto> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var unit = await _context.Units.AsNoTracking().FirstAsync(c=>c.Id==request.Id,cancellationToken);
            if (unit == null)
                return null;

            return new UnitDto
            {
                Id = unit.Id,
                UnitName = unit.UnitName
            };
        }
    }

}
