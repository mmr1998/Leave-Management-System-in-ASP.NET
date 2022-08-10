using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public int LeaveRequestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool cancelled { get; set; }

        public LeaveType LeaveType { get; set; }
    }
}