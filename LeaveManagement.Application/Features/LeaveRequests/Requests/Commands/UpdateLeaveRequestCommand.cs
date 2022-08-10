using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int LeaveRequestId { get; set; }
        public LeaveRequestDto leaveRequestDto { get; set; }
        public LeaveRequestApprovalDto leaveRequestApprovalDto { get; set; }
    }
}
