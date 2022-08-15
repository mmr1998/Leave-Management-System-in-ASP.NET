
using LeaveManagement.Application.Contracts.Persisence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveType> GetLeaveTypeWithDetails(int id)
        {
            var leaveType = await _dbContext.LeaveTypes
                .FirstOrDefaultAsync(q => q.LeaveTypeId == id);

            return leaveType;
        }

        public async Task<List<LeaveType>> GetLeaveTypeWithDetails()
        {
            var leaveTypes = await _dbContext.LeaveTypes
                .ToListAsync();

            return leaveTypes;
        }
    }
}
