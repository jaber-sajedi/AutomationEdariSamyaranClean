using AutomationEdariSamyaran.Application.MediatR.CompleteWorkflowStep.Command;
using AutomationEdariSamyaran.Application.MediatR.Workflow.Command;
using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Entities.Workflow;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Command
{
    public class CompleteWorkflowStepCommandHandler : IRequestHandler<CompleteWorkflowStepCommand, bool>
    {
        private readonly AppDbContext _context;

        public CompleteWorkflowStepCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CompleteWorkflowStepCommand request, CancellationToken cancellationToken)
        {
            var step = await _context.WorkflowInstanceSteps
                .Include(s => s.WorkflowStep)
                .FirstOrDefaultAsync(s => s.Id == request.WorkflowInstanceStepId, cancellationToken);

            if (step == null)
                throw new Exception("مرحله مورد نظر یافت نشد.");

            // ✅ مرحله فعلی را کامل کن
            step.IsCompleted = true;
            step.CompletedAt = DateTime.UtcNow;
            step.AssignedToId = request.CompletedById;

            // ✅ مرحله بعدی را پیدا کن
            var nextStep = await _context.WorkflowSteps
                .Where(s => s.WorkflowId == step.WorkflowStep.WorkflowId && s.Order > step.WorkflowStep.Order)
                .OrderBy(s => s.Order)
                .FirstOrDefaultAsync(cancellationToken);

            if (nextStep != null)
            {
                // مرحله بعدی در Instance ثبت شود
                var nextInstanceStep = new WorkflowInstanceStep
                {
                    WorkflowInstanceId = step.WorkflowInstanceId,
                    WorkflowStepId = nextStep.Id,
                    AssignedToId = null,
                    IsCompleted = false
                };

                await _context.WorkflowInstanceSteps.AddAsync(nextInstanceStep, cancellationToken);
            }
            else
            {
                // اگر مرحله بعدی وجود ندارد، WorkflowInstance پایان یافته است
                var instance = await _context.WorkflowInstances
                    .FirstOrDefaultAsync(i => i.Id == step.WorkflowInstanceId, cancellationToken);

                if (instance != null)
                    instance.IsCompleted = true;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
