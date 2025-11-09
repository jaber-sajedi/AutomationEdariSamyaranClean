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
    public class GetUnitByIdMeasurementQueryHandler : IRequestHandler<GetUnitByIdMeasurementQuery, Units_measurementDto>
    {
        private readonly AppDbContext _context;
        public GetUnitByIdMeasurementQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Units_measurementDto> Handle(GetUnitByIdMeasurementQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.UnitsMeasurements.AsNoTracking()
                              .Where(u => u.Id == request.Id) 
                              .Select(u => new Units_measurementDto
                              {
                                  Id = u.Id,
                                  Name_Measurement = u.NameMeasurement,
                              })
                              .FirstOrDefaultAsync(cancellationToken);



            if (query != null)
                return query;

            return null;
        }
    }
}
