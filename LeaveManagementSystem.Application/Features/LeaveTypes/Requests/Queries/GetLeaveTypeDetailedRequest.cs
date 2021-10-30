using LeaveManagementSystem.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailedRequest : IRequest<LeaveTypeDto>
    {
        public int id { get; set; }
    }
}
