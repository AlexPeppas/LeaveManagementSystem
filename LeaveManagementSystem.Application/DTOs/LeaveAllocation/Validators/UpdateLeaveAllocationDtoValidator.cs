using FluentValidation;
using LeaveManagementSystem.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));

            RuleFor(it => it.Id).NotNull().WithMessage("{PropertyName} cannot be null !");
           /*

            RuleFor(it => it.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} cannot be null")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(it => it.Id)
                .MustAsync(async (id, token) =>
                {
                    var leaveAllocExists = await _leaveAllocationRepository.Exists(id);
                    return leaveAllocExists;
                })
                .WithMessage("{PropertyName} does not exist");*/

        }
    }
}
