using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Commands;
using AutomationEdariSamyaran.Application.MediatR.Units.Queries;
using AutomationEdariSamyaran.Application.MediatR.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnitController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-unit")]
        public async Task<IActionResult> CreateUnit(string name)
        {
            var result = await _mediator.Send(new CreateUnitCommand( name));

            if (!result)
                return NotFound();

            return Ok($"New unit name add: {name}");
        }

        [HttpGet("get-all-unit")]
        public async Task<IActionResult> GetAllUnits()
        {
            var query = new GetAllUnitsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}/get-unit")]
        public async Task<IActionResult> GetUnitById(int id)
        {
            var query = new GetUnitByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("update-unit")]
        public async Task<IActionResult> UpdateUnit(UnitDto unit)
        {
            var result = await _mediator.Send(new UpdateUnitCommand(unit.Id, unit.UnitName));

            if (!result)
                return NotFound();

            return Ok(unit); 
        }
  
        [HttpDelete("{id:int}/delete-unit")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var result = await _mediator.Send(new DeleteUnitCommand(id));
            if (!result)
                return NotFound();

            return Ok($"Unit with Id:{id} is delete");
        }
    }

}
