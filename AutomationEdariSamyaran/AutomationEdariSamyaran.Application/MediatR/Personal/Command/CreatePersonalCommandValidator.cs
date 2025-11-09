using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Personal.Command
{
    public class CreatePersonalCommandValidator : AbstractValidator<CreatePersonalCommand>
    {
        public CreatePersonalCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("نام و نام خانوادگی الزامی است.")
                .MaximumLength(100).WithMessage("طول نام نباید بیش از ۱۰۰ کاراکتر باشد.");

            RuleFor(x => x.PersonalCode)
                .NotEmpty().WithMessage("کد پرسنلی الزامی است.")
                .Matches(@"^\d+$").WithMessage("کد پرسنلی باید فقط شامل عدد باشد.")
                .MaximumLength(20).WithMessage("کد پرسنلی نباید بیش از ۲۰ رقم باشد.");

            RuleFor(x => x.IdPosition)
                .NotNull().WithMessage("سمت پرسنل باید مشخص شود.");

            RuleFor(x => x.IdDepartment)
                .NotNull().WithMessage("دپارتمان باید مشخص شود.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("آدرس ایمیل نامعتبر است.");

            RuleFor(x => x.Phone)
                .Matches(@"^0\d{9,10}$").When(x => !string.IsNullOrWhiteSpace(x.Phone))
                .WithMessage("شماره تلفن باید با ۰ شروع شود و حداقل ۱۰ رقم داشته باشد.");


            RuleFor(x => x.NationalCode)
                .NotEmpty().WithMessage("کد ملی الزامی است.")
                .Length(10).WithMessage("کد ملی باید ۱۰ رقم باشد.")
                .Matches(@"^\d+$").WithMessage("کد ملی فقط باید شامل عدد باشد.");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now).When(x => x.BirthDate.HasValue)
                .WithMessage("تاریخ تولد نمی‌تواند در آینده باشد.");

            RuleFor(x => x.EmploymentEndDate)
                .GreaterThanOrEqualTo(x => x.EmploymentStartDate)
                .When(x => x.EmploymentEndDate.HasValue && x.EmploymentStartDate.HasValue)
                .WithMessage("تاریخ پایان استخدام نمی‌تواند قبل از شروع باشد.");

            RuleFor(x => x.BankAccountNumber)
                .Matches(@"^\d{10,24}$").When(x => !string.IsNullOrWhiteSpace(x.BankAccountNumber))
                .WithMessage("شماره حساب باید بین ۱۰ تا ۲۴ رقم باشد.");

            RuleFor(x => x.BankName)
                .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.BankName))
                .WithMessage("نام بانک نباید بیش از ۵۰ کاراکتر باشد.");

            RuleFor(x => x.NumberOfChildren)
                .GreaterThanOrEqualTo(0).WithMessage("تعداد فرزندان نمی‌تواند منفی باشد.");

            RuleFor(x => x.EmergencyContactPhone)
                .Matches(@"^09\d{9}$").When(x => !string.IsNullOrWhiteSpace(x.EmergencyContactPhone))
                .WithMessage("شماره تماس اضطراری باید معتبر باشد.");
        }
    }
}
