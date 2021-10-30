using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator()
        {
            RuleFor(it => it.Period)
                .NotNull()
                .GreaterThan(0)
                .LessThan(50);

            RuleFor(it => it.LeaveTypeId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
