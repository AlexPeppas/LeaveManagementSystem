using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveAllocation;
using LeaveManagementSystem.Application.DTOs.LeaveAllocation.Validators;
using LeaveManagementSystem.Application.Exceptions;
using LeaveManagementSystem.Application.Features.LeaveAllocation.Requests.Queries;
using LeaveManagementSystem.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveAllocation.Handlers.Queries
{
    public class GetLeaveAllocationDetailedRequestHandler : IRequestHandler<GetLeaveAllocationDetailedRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailedRequestHandler(ILeaveAllocationRepository leaveAllocationRepository , IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailedRequest request, CancellationToken cancellationToken)
        {
            var validator = new ILeaveAllocationDtoValidator(_leaveAllocationRepository);
            var res = await validator.ValidateAsync(new LeaveAllocationDto { Id = request.id });
            if (!res.IsValid) throw new ValidationException(res);

            var leaveAllocationDetailed = await _leaveAllocationRepository.GetAsync(request.id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocationDetailed);
        }
    }
}
