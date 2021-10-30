using LeaveManagementSystem.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateApprovalRequest : IRequest<Unit>
    {
        public ChangeApprovalRequestDto Payload { get; set; }
    }
}
