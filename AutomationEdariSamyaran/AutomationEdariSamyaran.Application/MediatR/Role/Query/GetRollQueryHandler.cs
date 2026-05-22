using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationEdariSamyaran.Application.Interfaces;
 
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Query
{
    public record GetRollQueryHandler : IRequestHandler<GetRollQuery, List<Domain.Entities.Role>>
    {
        private readonly IAppDbContext _context;
        public GetRollQueryHandler(IAppDbContext context)=>_context=context;
        
        public async Task<List<Domain.Entities.Role>> Handle(GetRollQuery request, CancellationToken cancellationToken)
        {
            return await _context.Roles.OrderBy(r => r.Name).ToListAsync(cancellationToken);
        }
    }
}
