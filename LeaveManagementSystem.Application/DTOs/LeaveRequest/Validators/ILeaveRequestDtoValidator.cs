using FluentValidation;
using LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(it => it.StartDate)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("{PropertyName} must be greater or equal to current date ")
                .LessThanOrEqualTo(DateTime.Now.Date.AddDays(100)).WithMessage("{PropertyName} must cannot exceed {ComparisonValue} days from today");

            RuleFor(it => it.EndDate)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("{PropertyName} must be greater or equal to current date ")
                .LessThanOrEqualTo(DateTime.Now.Date.AddDays(100)).WithMessage("{PropertyName} must cannot exceed {ComparisonValue} days from today");

            RuleFor(it => it.RequestComments)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .MaximumLength(1000).WithMessage("{PropertyName}'s length cannot exceed {ComparisonValue} characters");

            RuleFor(it => it.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var exists = await _leaveRequestRepository.Exists(id);
                    return exists;
                }).WithMessage("{PropertyName} does not exist !");
        }

        
    }
}
