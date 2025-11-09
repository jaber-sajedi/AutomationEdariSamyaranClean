using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Commands;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Handler
{
    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand,bool>
    {
        private readonly AppDbContext _dbContext;
        public CreateUnitCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        async Task<bool> IRequestHandler<CreateUnitCommand, bool>.Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.UnitName)) return false;
            Domain.Entities.Units unit = new Domain.Entities.Units();
            unit.UnitName = request.UnitName;

            _dbContext.Set<Domain.Entities.Units>().Add(unit);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
