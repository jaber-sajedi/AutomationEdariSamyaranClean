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
    public class GetRollByIdQueryHandler : IRequestHandler<GetRollByIdQuery, Domain.Entities.Role>
    {
        private readonly AppDbContext _context;
        public GetRollByIdQueryHandler(AppDbContext context)=>_context=context;
         

        public async Task<Domain.Entities.Role> Handle(GetRollByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FindAsync(request.roleId);
            if (role == null)
                throw new KeyNotFoundException($"Role with Id {request.roleId} not found.");
            return role;


        }
    }
}
