using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : Controller
    {
        private readonly IMediator _mediator;
        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        // GET: LeaveTypeController
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeListDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest { });
            return Ok(leaveTypes);
        }

        // GET: LeaveTypeController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest
            {
                LeaveTypeId = id
            });
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommand { leaveTypeDto = leaveType };
            var response = await _mediator.Send(command);   
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand { leaveTypeDto = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { LeaveTypeId = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
