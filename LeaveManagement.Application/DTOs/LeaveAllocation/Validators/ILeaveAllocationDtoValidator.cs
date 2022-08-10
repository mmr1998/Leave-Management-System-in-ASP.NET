using FluentValidation;
using LeaveManagement.Application.Persisence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NoOfDays)
                .GreaterThan(0).WithMessage("{PropertyName}  Must greater than {ComparisonValue}");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} Must Be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);

                    return !leaveTypeExists;
                })
                .WithMessage("{PropertyName} Does not exist!");
        }
    }
}
