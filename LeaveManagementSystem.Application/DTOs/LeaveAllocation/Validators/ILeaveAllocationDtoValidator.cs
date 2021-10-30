using FluentValidation;
using LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {

            _leaveAllocationRepository = leaveAllocationRepository;
            
            RuleFor(it => it.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} cannot be null")
                .NotEmpty()
                .GreaterThan(0).WithMessage("{PropertyName} bust me greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var returns = await _leaveAllocationRepository.Exists(id);
                    return returns;
                }).WithMessage("{PropertyName} does not exist !");

            RuleFor(it => it.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} bust me greater than {ComparisonValue}");

            RuleFor(it => it.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");
            
        }
    }
}
