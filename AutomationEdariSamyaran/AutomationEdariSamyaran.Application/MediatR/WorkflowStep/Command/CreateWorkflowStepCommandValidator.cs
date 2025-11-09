using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Command
{
    public class CreateWorkflowStepCommandValidator : AbstractValidator<CreateWorkflowStepCommand>
    {
        public CreateWorkflowStepCommandValidator()
        {
            RuleFor(x => x.WorkflowId)
                .GreaterThan(0)
                .WithMessage("شناسه گردش کار باید بزرگتر از صفر باشد.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام مرحله الزامی است.")
                .MaximumLength(100).WithMessage("طول نام مرحله نباید بیشتر از ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.Order)
                .GreaterThan(0)
                .WithMessage("شماره ترتیب باید بزرگتر از صفر باشد.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .When(x => x.RoleId.HasValue)
                .WithMessage("در صورت وارد کردن نقش، شناسه نقش باید بزرگتر از صفر باشد.");
        }
    }
}
