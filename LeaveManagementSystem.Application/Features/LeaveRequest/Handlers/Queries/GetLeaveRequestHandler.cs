using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Queries;
using LeaveManagementSystem.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LeaveManagementSystem.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestData = await _leaveRequestRepository.GetAsync(request.id);
            return _mapper.Map<LeaveRequestDto>(leaveRequestData);
        }
    }
}
