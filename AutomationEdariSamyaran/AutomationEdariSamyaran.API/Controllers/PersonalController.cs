using AutomationEdariSamyaran.Application.MediatR.Personal.Command;
using AutomationEdariSamyaran.Application.MediatR.Personal.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonalCommand command)
        {
            var id =await _mediator.Send(command);
            return Ok(new { personalId = id, message = "اطلاعات پرسنل جدید با موفقیت ثبت شد." });

        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPersonalsQuery());
            return Ok(result);
        }
    }
}
