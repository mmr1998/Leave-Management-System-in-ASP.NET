using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is Must!")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} Can't More Than {ComparisonValue} Char!");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is Must!")
                .GreaterThan(0).WithMessage("{PropertyName} Should be More than {ComparisonValue}!")
                .LessThan(24).WithMessage("{PropertyName} Should Not be More than {ComparisonValue}!");
        }
    }
}
