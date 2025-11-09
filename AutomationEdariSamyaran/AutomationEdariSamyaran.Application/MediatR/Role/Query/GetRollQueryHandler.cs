using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Query
{
    public record GetRollQueryHandler : IRequestHandler<GetRollQuery, List<Domain.Entities.Role>>
    {
        private readonly AppDbContext _context;
        public GetRollQueryHandler(AppDbContext context)=>_context=context;
        
        public async Task<List<Domain.Entities.Role>> Handle(GetRollQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.OrderBy(r => r.Name).ToListAsync(cancellationToken);
        }
    }
}
