using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.LeaveTypeId).NotNull().WithMessage("{PropertyName} Must be Present!");
        }
    }
}
