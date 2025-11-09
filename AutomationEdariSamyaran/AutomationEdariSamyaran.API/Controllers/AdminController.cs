using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Users.Queries;
using AutomationEdariSamyaran.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _mediator.Send(new LoginQuery { UserName = userName, Password = password });

            if (!result.Item1) 
            {
                return BadRequest(new { message = result.Item3 });
            }

            return Ok(new { token = result.Item2, message = "ورود موفق بود." });

        }
    }
}
