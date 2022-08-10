using LeaveManagement.Application.DTOs.Common;
using LeaveManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationListDto : BaseDto
    {
        public int LeaveAllocationId { get; set; }
        public int NoOfDays { get; set; }
        public int Period { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
    }
}
