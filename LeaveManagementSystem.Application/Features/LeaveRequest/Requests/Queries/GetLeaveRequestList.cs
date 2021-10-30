using LeaveManagementSystem.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Queries
{
    public class GetLeaveRequestList : IRequest<List<LeaveRequestDto>>
    {
    }
}
