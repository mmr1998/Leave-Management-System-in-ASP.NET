using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public int LeaveTypeId { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}