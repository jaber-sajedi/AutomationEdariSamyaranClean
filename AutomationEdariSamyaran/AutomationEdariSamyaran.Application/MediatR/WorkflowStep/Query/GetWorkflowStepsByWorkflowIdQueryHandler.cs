using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query
{
    public class GetWorkflowStepsByWorkflowIdQueryHandler : IRequestHandler<GetWorkflowStepsByWorkflowIdQuery, List<WorkflowStepDto>>
    {
        private readonly AppDbContext _context;

        public GetWorkflowStepsByWorkflowIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkflowStepDto>> Handle(GetWorkflowStepsByWorkflowIdQuery request, CancellationToken cancellationToken)
        {
            var steps = await _context.WorkflowSteps
                .Include(r=>r.Role)
                .Where(s => s.WorkflowId == request.WorkflowId)
                .OrderBy(s => s.Order)
                .Select(s => new WorkflowStepDto
                {
                    Id = s.Id,
                    WorkflowId = s.WorkflowId,
                    Name = s.Name,
                    Order = s.Order,
                    Role = new RoleDto
                    {
                        Id = s.Role.Id,
                        Name = s.Role.Name
                    }

                })
                .ToListAsync(cancellationToken);

            return steps;
        }
    }
}
 
