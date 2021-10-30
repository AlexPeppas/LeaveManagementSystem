using LeaveManagementSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }
    }
}
