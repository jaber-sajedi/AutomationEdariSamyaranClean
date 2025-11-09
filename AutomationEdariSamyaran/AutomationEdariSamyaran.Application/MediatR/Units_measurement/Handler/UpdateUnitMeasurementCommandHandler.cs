using AutomationEdariSamyaran.Application.MediatR.Units_measurement.Commands;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Handler
{
    public class UpdateUnitMeasurementCommandHandler : IRequestHandler<UpdateUnitMeasurementCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateUnitMeasurementCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateUnitMeasurementCommand request, CancellationToken cancellationToken)
        {
            var Unit = await _context.UnitsMeasurements.AsNoTracking().Where(c => c.Id == request.Id).Select(
                u => new Unitsmeasurement
                {
                    Id = u.Id,
                    NameMeasurement = u.NameMeasurement
                }).FirstOrDefaultAsync();

            if (Unit == null)
                return false;

            _context.Set<Unitsmeasurement>().Update(Unit);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
