using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Entities.Workflow;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Command
{
    public class StartWorkflowInstanceCommandHandler : IRequestHandler<StartWorkflowInstanceCommand, int>
    {
        private readonly AppDbContext _context;

        public StartWorkflowInstanceCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(StartWorkflowInstanceCommand request, CancellationToken cancellationToken)
        {
            // بررسی وجود Workflow
            var workflow = await _context.Workflows
                .FirstOrDefaultAsync(w => w.Id == request.WorkflowId, cancellationToken);

            if (workflow == null)
                throw new Exception($"Workflow با Id = {request.WorkflowId} یافت نشد.");

            var instance = new WorkflowInstance
            {
                WorkflowId = request.WorkflowId,
                PersonalId = request.InitiatorId,
                StartedAt = DateTime.UtcNow,
                IsCompleted = false // اضافه کردن مقدار پیش‌فرض
            };

            _context.WorkflowInstances.Add(instance);
            await _context.SaveChangesAsync(cancellationToken);

            // ایجاد اولین مرحله
            var firstStep = await _context.WorkflowSteps
                .Where(s => s.WorkflowId == request.WorkflowId)
                .OrderBy(s => s.Order)
                .FirstOrDefaultAsync(cancellationToken);

            if (firstStep != null)
            {
                var instanceStep = new WorkflowInstanceStep
                {
                    WorkflowInstanceId = instance.Id,
                    WorkflowStepId = firstStep.Id,
                    AssignedToId = null,  // اگر Required است، باید مقدار معتبری بدهی
                    IsCompleted = false
                };
                _context.WorkflowInstanceSteps.Add(instanceStep);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return instance.Id;
        }

    }
}
