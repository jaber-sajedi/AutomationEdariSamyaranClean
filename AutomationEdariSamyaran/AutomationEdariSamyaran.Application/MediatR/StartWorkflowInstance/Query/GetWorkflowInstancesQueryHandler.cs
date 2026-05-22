 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationEdariSamyaran.Application.Interfaces;
using AutomationEdariSamyaran.Domain.Entities.Workflow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Query
{
    public class GetWorkflowInstancesQueryHandler : IRequestHandler<GetWorkflowInstancesQuery, List<WorkflowInstance>>
    {
        private readonly IAppDbContext _context;
        public GetWorkflowInstancesQueryHandler(IAppDbContext context) => _context = context;

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
