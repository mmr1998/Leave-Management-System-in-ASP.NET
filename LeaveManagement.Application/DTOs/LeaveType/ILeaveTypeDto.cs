﻿using LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveType
{
    public interface ILeaveTypeDto 
    {
        public int LeaveTypeId { get; set; }
        public string Name { get; set; }
        public int? DefaultDays { get; set; }
    }
}
