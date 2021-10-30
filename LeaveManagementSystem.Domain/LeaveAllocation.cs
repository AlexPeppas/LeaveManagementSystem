using LeaveManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        
        public int NumberOfDays { get; set; }
        
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
