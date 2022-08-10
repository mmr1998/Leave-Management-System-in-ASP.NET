using LeaveManagement.Application.DTOs.Common;
using LeaveManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
    {
        public int LeaveRequestId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime? DateRequested { get; set; }
        public string? RequestComments { get; set; }

    }
}
