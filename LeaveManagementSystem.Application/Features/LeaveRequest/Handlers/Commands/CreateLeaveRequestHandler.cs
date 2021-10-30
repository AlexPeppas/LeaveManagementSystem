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
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequest, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
        {
            var validator = new ILeaveRequestDtoValidator(_leaveRequestRepository);
            var validation = await validator.ValidateAsync(request.Payload);
            if (!validation.IsValid) throw new ValidationException(validation); //throw new Exception(string.Concat(validation.Errors, " , "));

            var leaveRequest = _mapper.Map<LeaveManagementSystem.Domain.LeaveRequest>(request.Payload);
            var result = await _leaveRequestRepository.AddAsync(leaveRequest);
            return result.Id;
        }
    }
}
