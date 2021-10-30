using LeaveManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
