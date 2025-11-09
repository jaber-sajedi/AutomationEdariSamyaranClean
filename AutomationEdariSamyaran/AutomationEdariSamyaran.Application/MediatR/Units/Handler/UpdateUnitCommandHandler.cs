using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Commands;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Handler
{
    public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateUnitCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var query = await _context.Units.Where(c => c.Id == request.Id).Select(u => new Domain.Entities.Units
            {
                Id = u.Id,
                UnitName = u.UnitName
            }).FirstOrDefaultAsync();

            if (query == null)
                return false;

            query.UnitName = request.Name;

            _context.Units.Update(query);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
            
        }
    }
}
