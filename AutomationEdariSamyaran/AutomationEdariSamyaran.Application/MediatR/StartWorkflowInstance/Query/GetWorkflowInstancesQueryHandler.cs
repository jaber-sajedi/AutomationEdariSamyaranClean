using AutomationEdariSamyaran.Domain.Entities.Workflow;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Query
{
    public class GetWorkflowInstancesQueryHandler : IRequestHandler<GetWorkflowInstancesQuery, List<WorkflowInstance>>
    {
        private readonly AppDbContext _context;
        public GetWorkflowInstancesQueryHandler(AppDbContext context) => _context = context;

        public async Task<List<WorkflowInstance>> Handle(GetWorkflowInstancesQuery request, CancellationToken cancellationToken)
        {
            return await _context.WorkflowInstances
                .Where(i => i.WorkflowId == request.WorkflowId)
                .Include(i => i.Personal)
                .OrderByDescending(i => i.StartedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
