using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Persisence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);


            var leaveRequest = await _leaveRequestRepository.Get(request.LeaveRequestId);

            if (request.leaveRequestDto != null)
            {
                _mapper.Map(request.leaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.leaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.leaveRequestApprovalDto.Approved);
            }
            

            return Unit.Value;
        }
    }
}
