using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : Controller
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        // GET: LeaveAllocationController
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationListDto>>> Get()
        {
            var LeaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest { });
            return Ok(LeaveAllocations);
        }

        // GET: LeaveAllocationController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get(int id)
        {
            var LeaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest
            {
                LeaveAllocationId = id
            });
            return Ok(LeaveAllocation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto LeaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { leaveAllocationDto = LeaveAllocation };
            var response = await _mediator.Send(command);   
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] UpdateLeaveAllocationDto LeaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { leaveAllocationDto = LeaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { LeaveAllocationId = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
