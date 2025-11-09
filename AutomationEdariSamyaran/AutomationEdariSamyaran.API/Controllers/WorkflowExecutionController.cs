using AutomationEdariSamyaran.Application.MediatR.CompleteWorkflowStep.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowExecutionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowExecutionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ تکمیل یک مرحله از WorkflowInstance
        [HttpPost("complete-step")]
        public async Task<IActionResult> CompleteStep([FromBody] CompleteWorkflowStepCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
                return Ok(new { success = true, message = "مرحله با موفقیت تکمیل شد." });

            return BadRequest(new { success = false, message = "عملیات تکمیل مرحله ناموفق بود." });
        }
    }
}
