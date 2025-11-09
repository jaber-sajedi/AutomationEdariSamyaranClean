using AutomationEdariSamyaran.Application.MediatR.Workflow.Command;
using AutomationEdariSamyaran.Application.MediatR.Workflow.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkflowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ ایجاد جریان کاری جدید
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateWorkflowCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { workflowId = id, message = "جریان کاری با موفقیت ایجاد شد." });
        }

        // ✅ دریافت لیست جریان‌ها
        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetWorkflowsQuery());
            return Ok(result);
        }
    }
}
