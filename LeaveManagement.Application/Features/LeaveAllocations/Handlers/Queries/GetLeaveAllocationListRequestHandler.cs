using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using LeaveManagement.Application.Persisence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationListDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationListDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();

            return _mapper.Map<List<LeaveAllocationListDto>>(leaveAllocations);

        }
    }
}
