using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Query
{
    public class GetWorkflowsQueryHandler : IRequestHandler<GetWorkflowsQuery, List<Domain.Entities.Workflow.Workflow>>
    {
        private readonly AppDbContext _context;
        public GetWorkflowsQueryHandler(AppDbContext context) => _context = context;

        public async Task<List<Domain.Entities.Workflow.Workflow>> Handle(GetWorkflowsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Workflows
                .OrderBy(w => w.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
