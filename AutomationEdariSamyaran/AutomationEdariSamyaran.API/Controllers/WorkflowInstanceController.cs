using AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Command;
using AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowInstanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowInstanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ ایجاد یک WorkflowInstance جدید (شروع جریان کاری)
        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] StartWorkflowInstanceCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { instanceId = id, message = "گردش‌کار آغاز شد." });
        }

        // ✅ دریافت مراحل فعال و کامل‌شده‌ی هر Instance
        [HttpGet("steps/{instanceId}")]
        public async Task<IActionResult> GetSteps(int instanceId)
        {
            var result = await _mediator.Send(new GetWorkflowInstanceStepsQuery(instanceId));
            return Ok(result);
        }
    }
}
