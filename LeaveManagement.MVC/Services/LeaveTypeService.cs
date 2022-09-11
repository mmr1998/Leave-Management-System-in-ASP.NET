using AutoMapper;
using LeaveManagement.MVC.Contracts;
using LeaveManagement.MVC.Models;
using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService , ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public LeaveTypeService(ILocalStorageService localStorageService, IMapper mapper, IClient httpClient) : base(localStorageService,httpClient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpClient = httpClient;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypeAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);  
        }
        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypeGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

    }
}
