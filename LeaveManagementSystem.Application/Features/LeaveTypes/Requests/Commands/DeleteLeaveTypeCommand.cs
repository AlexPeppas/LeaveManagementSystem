﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    
    }
}
