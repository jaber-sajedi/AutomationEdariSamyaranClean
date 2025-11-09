using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Command
{
   
    public class CreateWorkflowStepCommandHandler : IRequestHandler<CreateWorkflowStepCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateWorkflowStepCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateWorkflowStepCommand request, CancellationToken cancellationToken)
        {
            var step = new Domain.Entities.WorkflowStep
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
