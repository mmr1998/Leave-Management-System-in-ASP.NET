using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Persisence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeListDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeListDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetLeaveTypeWithDetails();

            return _mapper.Map<List<LeaveTypeListDto>>(leaveTypes);

        }
    }
}
