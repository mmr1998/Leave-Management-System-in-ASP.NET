using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveAllocation mappings
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationListDto>().ReverseMap();
            #endregion LeaveAllocation mappings

            #region LeaveRequest mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest mappings

            #region LeaveType mappings
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeListDto>().ReverseMap();
            #endregion LeaveType mappings
        }
    }
}
