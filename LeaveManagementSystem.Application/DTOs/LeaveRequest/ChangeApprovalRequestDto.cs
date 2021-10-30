using LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class ChangeApprovalRequestDto : BaseDto
    {
        public bool? Approved { get; set; }
    }
}
