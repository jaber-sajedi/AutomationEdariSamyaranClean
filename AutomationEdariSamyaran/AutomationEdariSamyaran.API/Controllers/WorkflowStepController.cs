using AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Command;
using AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowStepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowStepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ افزودن مرحله به یک Workflow
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateWorkflowStepCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { stepId = id, message = "مرحله با موفقیت ایجاد شد." });
        }

        // ✅ دریافت مراحل یک Workflow
        [HttpGet("get-by-workflow/{workflowId}")]
        public async Task<IActionResult> GetByWorkflow(int workflowId)
        {
            var result = await _mediator.Send(new GetWorkflowStepsByWorkflowIdQuery(workflowId));
            return Ok(result);
        }
    }
}
