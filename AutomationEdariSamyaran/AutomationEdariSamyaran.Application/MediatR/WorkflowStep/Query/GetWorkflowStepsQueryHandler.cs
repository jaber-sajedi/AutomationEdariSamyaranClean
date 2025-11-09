using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query
{
    public class GetWorkflowStepsQueryHandler : IRequestHandler<GetWorkflowStepsQuery, List<WorkflowStep>>
    {
        private readonly AppDbContext _context;
        public GetWorkflowStepsQueryHandler(AppDbContext context) => _context = context;

        public async Task<List<WorkflowStep>> Handle(GetWorkflowStepsQuery request, CancellationToken cancellationToken)
        {
            return await _context.WorkflowSteps
                .Where(s => s.WorkflowId == request.WorkflowId)
                .OrderBy(s => s.Order)
                .ToListAsync(cancellationToken);
        }
    }
}
