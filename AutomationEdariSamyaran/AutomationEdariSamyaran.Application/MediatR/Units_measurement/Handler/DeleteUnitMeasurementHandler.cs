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

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Handler
{
    public class DeleteUnitMeasurementHandler : IRequestHandler<DeleteUnitMeasurementCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteUnitMeasurementHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteUnitMeasurementCommand request, CancellationToken cancellationToken)
        {

            var unit = await _context.UnitsMeasurements.AsNoTracking().Where(c => c.Id == request.Id)
                .Select(u => new Unitsmeasurement
                {
                    Id = u.Id,
                    NameMeasurement = u.NameMeasurement
                }).FirstOrDefaultAsync();


            if (unit != null)
            {
                _context.Set<Unitsmeasurement>().Remove(unit);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
