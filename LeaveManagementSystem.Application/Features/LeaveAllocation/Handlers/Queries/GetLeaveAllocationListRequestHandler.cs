﻿using AutoMapper;
using LeaveManagementSystem.Application.DTOs.LeaveAllocation;
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
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var LeaveAllocationList = await _leaveAllocationRepository.GetAllAsync();
            return _mapper.Map<List<LeaveAllocationDto>>(LeaveAllocationList);
        }
    }
}
