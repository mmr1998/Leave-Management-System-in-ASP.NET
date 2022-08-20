using AutoMapper;
using LeaveManagement.MVC.Contracts;
using LeaveManagement.MVC.Models;
using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC.Services
{
    public class LeaveTypeService : BaseHttpService //, ILeaveTypeService
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

        //public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        //{
        //    try
        //    {
        //        var response = new Response<int>();
        //        CreateLeaveTypeDto createLeaveType = _mapper.Map<CreateLeaveTypeDto>(leaveType);
        //        var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveType);

        //    }
        //}

    }
}
