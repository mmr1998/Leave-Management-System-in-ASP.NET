using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : Controller
    {
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        // GET: LeaveRequestController
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var LeaveRequests = await _mediator.Send(new GetLeaveRequestListRequest { });
            return Ok(LeaveRequests);
        }

        // GET: LeaveRequestController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get(int id)
        {
            var LeaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest
            {
                LeaveRequestId = id
            });
            return Ok(LeaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto LeaveRequest)
        {
            var command = new CreateLeaveRequestCommand { leaveRequestDto = LeaveRequest };
            var response = await _mediator.Send(command);   
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveRequestDto LeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { LeaveRequestId = id , leaveRequestDto = LeaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("approvalstatus/{id}")]
        public async Task<ActionResult> ChangeApproval(int id,[FromBody] LeaveRequestApprovalDto requestApprovalDto)
        {
            var command = new UpdateLeaveRequestCommand { LeaveRequestId = id ,leaveRequestApprovalDto = requestApprovalDto};
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { LeaveRequestId = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
