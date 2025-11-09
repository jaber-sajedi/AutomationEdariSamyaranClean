using AutomationEdariSamyaran.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Queries
{
    public class GetUnitMeasurementQuery:IRequest<List<Units_measurementDto>>
    {
    }
}
