using LeaveManagementSystem.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequest : IRequest<LeaveRequestDto>
    {
        public int id { get; set; }
    }
}
