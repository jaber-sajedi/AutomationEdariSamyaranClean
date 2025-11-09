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
    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, bool>
    {
        private readonly AppDbContext _dbContext;
        public DeleteUnitCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.Units.AsNoTracking().FirstOrDefaultAsync(c => c.Id == request.Id);

            if (query!=null)
            {
                _dbContext.Units.Remove((Domain.Entities.Units)query);
                await  _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;

        }
    }
}
