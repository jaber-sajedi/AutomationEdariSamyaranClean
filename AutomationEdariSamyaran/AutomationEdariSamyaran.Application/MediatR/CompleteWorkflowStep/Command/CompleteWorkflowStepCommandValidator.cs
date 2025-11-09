using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.CompleteWorkflowStep.Command
{
    public class CompleteWorkflowStepCommandValidator : AbstractValidator<CompleteWorkflowStepCommand>
    {
        public CompleteWorkflowStepCommandValidator()
        {
            RuleFor(x => x.WorkflowInstanceStepId)
                .GreaterThan(0).WithMessage("شناسه مرحله‌ی Workflow باید بزرگ‌تر از صفر باشد.");

            RuleFor(x => x.CompletedById)
                .GreaterThan(0).WithMessage("شناسه کاربر تکمیل‌کننده باید معتبر باشد.");
        }
    }
}
