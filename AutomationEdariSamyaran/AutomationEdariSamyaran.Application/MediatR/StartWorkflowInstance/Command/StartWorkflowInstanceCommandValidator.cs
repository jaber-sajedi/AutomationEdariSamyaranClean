using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Command
{
    public class StartWorkflowInstanceCommandValidator : AbstractValidator<StartWorkflowInstanceCommand>
    {
        public StartWorkflowInstanceCommandValidator()
        {
            RuleFor(x => x.WorkflowId)
                .GreaterThan(0)
                .WithMessage("شناسه گردش کار باید بزرگتر از صفر باشد.");

            RuleFor(x => x.InitiatorId)
                .GreaterThan(0)
                .WithMessage("شناسه آغازگر باید بزرگتر از صفر باشد.");
        }
    }
}
