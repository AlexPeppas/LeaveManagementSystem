using LeaveManagementSystem.Application.DTOs.LeaveType;
using LeaveManagementSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands
{
    
    public class UpdateLeaveTypeCommand : IRequest<LeaveType>
    {
        public CreateLeaveTypeDto Payload { get; set; }
    }
    
}
