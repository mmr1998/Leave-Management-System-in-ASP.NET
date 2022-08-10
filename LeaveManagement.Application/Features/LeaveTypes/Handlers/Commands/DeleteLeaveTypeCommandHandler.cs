using AutoMapper;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Persisence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {            
            var leaveTypes = await _leaveTypeRepository.Get(request.LeaveTypeId);
            
            if(leaveTypes == null)
            {
                throw new NotFoundException(nameof(leaveTypes), request.LeaveTypeId);
            }


            await _leaveTypeRepository.Delete(leaveTypes);

            return Unit.Value;
        }
    }
}
