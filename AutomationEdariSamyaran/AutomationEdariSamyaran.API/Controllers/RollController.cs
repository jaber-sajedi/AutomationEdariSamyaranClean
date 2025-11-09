using AutomationEdariSamyaran.Application.MediatR.Role.Command;
using AutomationEdariSamyaran.Application.MediatR.Role.Query;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RollController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRollCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new {rollId=id, message ="نقش جدید با موقیت ایجاد شد."});
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetRollQuery());
            return Ok(result);
        }


        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody]GetRollByIdQuery command)
        {
            var result=await _mediator.Send(command);
            return Ok(result);
        }




    }
}
