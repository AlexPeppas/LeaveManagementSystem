using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveRequest.Validators;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Commands;
using LeaveManagementSystem.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequest, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequest request, CancellationToken cancellationToken)
        {
            var validator = new ILeaveRequestDtoValidator(_leaveRequestRepository);
            var validation = await validator.ValidateAsync(request.Payload);
            if (!validation.IsValid) throw new ValidationException(validation); //throw new Exception(string.Concat(validation.Errors, " , "));

            var leaveRequestEntity = await _leaveRequestRepository.GetAsync(request.Payload.Id);
            var itemToUpdate = _mapper.Map(request.Payload, leaveRequestEntity);

            await _leaveRequestRepository.UpdateAsync(itemToUpdate);
            return Unit.Value;
        }
    }
}
