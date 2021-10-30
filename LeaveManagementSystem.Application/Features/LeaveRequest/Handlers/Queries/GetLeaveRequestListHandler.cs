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
    public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestList, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestList request, CancellationToken cancellationToken)
        {
            var LeaveRequestList = await _leaveRequestRepository.GetAllAsync();
            return _mapper.Map<List<LeaveRequestDto>>(LeaveRequestList);
        }
    }
}
