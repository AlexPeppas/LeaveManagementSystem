using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(entity => entity.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be null.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters.");

            RuleFor(entity => entity.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} cannot be null.")
                .GreaterThan(0).WithMessage("{PropertyName} cannot be lower than 0.")
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100 days.");
        }
    }
}
