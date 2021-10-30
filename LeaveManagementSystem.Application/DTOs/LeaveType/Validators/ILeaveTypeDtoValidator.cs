using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {

            RuleFor(entity => entity.Name)
                    .NotEmpty().WithMessage("{PropertyName} cannot be null.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} cannot exceed {ComparisonValue} characters.");

            RuleFor(entity => entity.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} cannot be null.")
                .GreaterThan(0).WithMessage("{PropertyName} cannot be lower than {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} cannot exceed {ComparisonValue} days.");
        }
    }
}
