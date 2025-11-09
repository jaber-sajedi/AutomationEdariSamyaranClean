using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units_measurement.Queries;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Handler
{
    public class GetUnitMeasurementQueryHandler : IRequestHandler<GetUnitMeasurementQuery, List<Units_measurementDto>>
    {

        private readonly AppDbContext _context;
        public GetUnitMeasurementQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Units_measurementDto>> Handle(GetUnitMeasurementQuery request, CancellationToken cancellationToken)
        {
            var query=await _context.UnitsMeasurements.AsNoTracking().Select(u=>new Units_measurementDto {
            Id=u.Id,
            Name_Measurement=u.NameMeasurement
            }).ToListAsync();

            return query;
        }
    }
}
