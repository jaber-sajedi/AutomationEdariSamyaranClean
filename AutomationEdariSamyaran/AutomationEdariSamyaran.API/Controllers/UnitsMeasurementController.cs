using AutomationEdariSamyaran.Application.DTOs;
using AutomationEdariSamyaran.Application.MediatR.Units.Commands;
using AutomationEdariSamyaran.Application.MediatR.Units.Handler;
using AutomationEdariSamyaran.Application.MediatR.Units.Queries;
using AutomationEdariSamyaran.Application.MediatR.Units_measurement.Commands;
using AutomationEdariSamyaran.Application.MediatR.Units_measurement.Handler;
using AutomationEdariSamyaran.Application.MediatR.Units_measurement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomationEdariSamyaran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsMeasurementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnitsMeasurementController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("get-units-measurement")]
        public async Task<IActionResult> GetUnitsMeasurement()
        {
            var result = await _mediator.Send(new GetUnitMeasurementQuery());
            return Ok(result);
        }




        [HttpGet("get-unit-measurement-by-id")]
        public async Task<IActionResult> GetUnitsMeasurementById([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetUnitByIdMeasurementQuery { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("update-unit-measurement")]
        public async Task<IActionResult> UpdateUnit(Units_measurementDto unit)
        {
            var result = await _mediator.Send(new UpdateUnitMeasurementCommand(unit.Id, unit.Name_Measurement));

            if (!result)
                return NotFound();

            return Ok(unit);
        }

        [HttpDelete("{id:int}/delete-unit-measurement")]
        public async Task<IActionResult> DeleteUnitMeasurement(int id)
        {
            var result = await _mediator.Send(new DeleteUnitMeasurementCommand(id));
            if (!result)
                return NotFound();

            return Ok($"Unit with Id:{id} is delete");
        }

    }
}
