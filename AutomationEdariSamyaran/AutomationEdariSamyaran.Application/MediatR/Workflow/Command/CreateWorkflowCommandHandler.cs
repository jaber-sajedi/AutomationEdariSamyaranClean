
using AutomationEdariSamyaran.Application.Exceptions;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Command
{
    public class CreateWorkflowCommandHandler : IRequestHandler<CreateWorkflowCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateWorkflowCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateWorkflowCommand request, CancellationToken cancellationToken)
        {
            bool exists = await _context.Workflows
                .AnyAsync(w => w.Name == request.Name, cancellationToken);

            if (exists)
                throw AppException.Create(
                    $"جریانی با نام «{request.Name}» از قبل وجود دارد.",
                    HttpStatusCode.BadRequest,
                    "WORKFLOW_DUPLICATE");


            var workflow = new Domain.Entities.Workflow.Workflow
            {
                Name = request.Name,
                Description = request.Description
            };


            _context.Workflows.Add(workflow);
            await _context.SaveChangesAsync(cancellationToken);
            return workflow.Id;
        }
    }
}
