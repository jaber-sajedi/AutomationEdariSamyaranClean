 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationEdariSamyaran.Application.Interfaces;
using MediatR;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Command
{
   
    public class CreateWorkflowStepCommandHandler : IRequestHandler<CreateWorkflowStepCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateWorkflowStepCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateWorkflowStepCommand request, CancellationToken cancellationToken)
        {
            var step = new  Domain.Entities.Workflow.WorkflowStep
            {
                WorkflowId = request.WorkflowId,
                Name = request.Name,
                Order = request.Order,
                RoleId = request.RoleId
            };
            _context.WorkflowSteps.Add(step);
            await _context.SaveChangesAsync(cancellationToken);
            return step.Id;
        }
    }
}
