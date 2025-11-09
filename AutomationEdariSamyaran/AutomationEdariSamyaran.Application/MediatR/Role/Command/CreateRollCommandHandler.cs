using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Command
{
    public class CreateRollCommandHandler : IRequestHandler<CreateRollCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateRollCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateRollCommand request, CancellationToken cancellationToken)
        {
            var roll = new Domain.Entities.Role
            {
                Name = request.Name,
            };

            _context.Roles.Add(roll);
            await _context.SaveChangesAsync(cancellationToken);
            return roll.Id;

        }
    }
}
