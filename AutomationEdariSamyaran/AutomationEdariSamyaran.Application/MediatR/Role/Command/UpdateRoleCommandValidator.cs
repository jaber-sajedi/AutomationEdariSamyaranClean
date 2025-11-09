using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Command
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نقش باید معتبر باشد.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("نام نقش الزامی است.")
                .MaximumLength(100).WithMessage("نام نقش نباید بیش از ۱۰۰ کاراکتر باشد.")
                .Matches(@"^[\p{L}\d\s]+$").WithMessage("نام نقش فقط می‌تواند شامل حروف و عدد باشد.");
        }
    }
}
