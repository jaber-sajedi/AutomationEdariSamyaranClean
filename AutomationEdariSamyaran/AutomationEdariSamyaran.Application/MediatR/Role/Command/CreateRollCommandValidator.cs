using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Command
{
    public class CreateRollCommandValidator : AbstractValidator<CreateRollCommand>
    {
        public CreateRollCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام نقش الزامی است.")
                .MaximumLength(100).WithMessage("طول نام نقش نباید بیش از ۱۰۰ کاراکتر باشد.")
                .Matches(@"^[\p{L}\d\s]+$").WithMessage("نام نقش فقط باید شامل حروف و عدد باشد.");
        }
    }
}
