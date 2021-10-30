using AutoMapper;

using LeaveManagementSystem.Application.DTOs.LeaveType;
using LeaveManagementSystem.Application.DTOs.LeaveType.Validators;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagementSystem.Application.Persistence.Contracts;
using LeaveManagementSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,LeaveType>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveType> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new ILeaveTypeDtoValidator();
            var validation = await validator.ValidateAsync(request.Payload);

            if (!validation.IsValid) throw new ValidationException(validation);


            var LeaveTypeCreationData = _mapper.Map<LeaveType>(request.Payload);
            var result = await _leaveTypeRepository.UpdateAsync(LeaveTypeCreationData);
            return result;
        }
    }
}
