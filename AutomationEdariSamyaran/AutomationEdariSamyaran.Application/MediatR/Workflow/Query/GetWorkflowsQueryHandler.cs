 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationEdariSamyaran.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Query
{
    public class GetWorkflowsQueryHandler : IRequestHandler<GetWorkflowsQuery, List<Domain.Entities.Workflow.Workflow>>
    {
        private readonly IAppDbContext _context;
        public GetWorkflowsQueryHandler(IAppDbContext context) => _context = context;

        public async Task<List<Domain.Entities.Workflow.Workflow>> Handle(GetWorkflowsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Workflows
                .OrderBy(w => w.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
