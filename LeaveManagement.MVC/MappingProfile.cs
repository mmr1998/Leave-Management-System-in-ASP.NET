using AutoMapper;
using LeaveManagement.MVC.Models;
using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
