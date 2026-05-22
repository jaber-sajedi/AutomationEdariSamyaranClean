using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationEdariSamyaran.Application.Interfaces;
 
 
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query
{
    public class GetWorkflowInstanceStepsQueryHandler : IRequestHandler<GetWorkflowInstanceStepsQuery, List<WorkflowInstanceStepDto>>
    {
        private readonly IAppDbContext _context;

        public GetWorkflowInstanceStepsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkflowInstanceStepDto>> Handle(GetWorkflowInstanceStepsQuery request, CancellationToken cancellationToken)
        {
            var steps = await _context.WorkflowInstanceSteps
                .Include(s => s.WorkflowStep)
                .Where(s => s.WorkflowInstanceId == request.WorkflowInstanceId)
                .OrderBy(s => s.WorkflowStep.Order)
                .Select(s => new WorkflowInstanceStepDto
                {
                    Id = s.Id,
                    StepName = s.WorkflowStep.Name,
                    IsCompleted = s.IsCompleted,
                    AssignedToId = s.AssignedToId,
                    CompletedAt = s.CompletedAt,
                    Order = s.WorkflowStep.Order
                })
                .ToListAsync(cancellationToken);

            return steps;
        }
    }
}
