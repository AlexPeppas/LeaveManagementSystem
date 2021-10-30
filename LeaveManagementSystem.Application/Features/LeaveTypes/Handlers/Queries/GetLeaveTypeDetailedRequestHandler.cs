using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveType;
using LeaveManagementSystem.Application.DTOs.LeaveType.Validators;
using LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagementSystem.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailedRequestHandler : IRequestHandler<GetLeaveTypeDetailedRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailedRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailedRequest request, CancellationToken cancellationToken)
        {
            
            var leaveTypeDetailed = await _leaveTypeRepository.GetAsync(request.id);
            return _mapper.Map<LeaveTypeDto>(leaveTypeDetailed);
        }
    }
}
