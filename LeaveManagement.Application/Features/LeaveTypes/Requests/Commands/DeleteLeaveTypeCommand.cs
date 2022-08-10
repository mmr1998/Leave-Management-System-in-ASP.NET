﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteLeaveTypeCommand :IRequest
    {
        public int LeaveTypeId { get; set; }
    }
}
