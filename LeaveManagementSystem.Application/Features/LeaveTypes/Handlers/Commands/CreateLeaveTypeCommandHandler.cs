using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveType.Validators;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagementSystem.Application.Persistence.Contracts;
using LeaveManagementSystem.Application.Responses;
using LeaveManagementSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var basicResponse = new BaseCommandResponse();
            var validator = new ILeaveTypeDtoValidator();
            var validation = await validator.ValidateAsync(request.Payload);

            //1st approach
            //if (!validation.IsValid) throw new ValidationException(validation);
            //2nd approach
            /*var validator = new CreateLeaveTypeDtoValidator();
            var validation = await validator.ValidateAsync(request.Payload);
            if (!validation.IsValid) throw new Exception(string.Concat(validation.Errors, " , "));*/
            //3d approach

            if (!validation.IsValid)
            {
                basicResponse.Success = false;
                basicResponse.Message = "Creation Failed";
                basicResponse.Errors = validation.Errors.Select(it => it.ErrorMessage)?.ToList();
            }
            var LeaveTypeCreationData = _mapper.Map<LeaveType>(request.Payload);
            var result = await _leaveTypeRepository.AddAsync(LeaveTypeCreationData);

            basicResponse.Success = true;
            basicResponse.Message = "Creation Successful";
            basicResponse.RecordId = result.Id;
            //return result.Id;

            return basicResponse;
        }
    }
}
