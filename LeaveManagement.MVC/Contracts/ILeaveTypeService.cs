using LeaveManagement.MVC.Models;
using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTyepDetails(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType);
        Task<Response<int>> UpdateLeaveType(int id,LeaveTypeVM leaveType);
        Task<Response<int>> DeleteLeaveType(LeaveTypeVM leaveType);
    }
}
