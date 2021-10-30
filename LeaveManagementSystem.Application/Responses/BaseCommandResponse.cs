using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementSystem.Application.Responses
{
    public class BaseCommandResponse
    {
        public int RecordId { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
