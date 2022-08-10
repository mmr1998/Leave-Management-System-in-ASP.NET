using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int LeaveAllocationId { get; set; }
        public int NoOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public LeaveType LeaveType { get; set; }

    }
}