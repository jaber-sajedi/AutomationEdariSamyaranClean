using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Command
{
    public class CreateWorkflowCommandValidator: AbstractValidator<CreateWorkflowCommand>
    {
        public CreateWorkflowCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام Workflow الزامی است.")
                .MaximumLength(100).WithMessage("نام Workflow نباید بیش از 2۰۰ کاراکتر باشد.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("توضیحات نباید بیش از ۵۰۰ کاراکتر باشد.");
        }
    }
}
