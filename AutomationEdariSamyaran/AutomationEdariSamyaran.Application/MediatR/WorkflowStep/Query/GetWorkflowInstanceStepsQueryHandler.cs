using AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query.AutomationEdariSamyaran.Application.MediatR.WorkflowInstance.Query;
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
    public class GetWorkflowInstanceStepsQueryHandler : IRequestHandler<GetWorkflowInstanceStepsQuery, List<WorkflowInstanceStepDto>>
    {
        private readonly AppDbContext _context;

        public GetWorkflowInstanceStepsQueryHandler(AppDbContext context)
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
