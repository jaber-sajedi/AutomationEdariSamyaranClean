using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Commands
{
    public class DeleteUnitMeasurementCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteUnitMeasurementCommand(int id)
        {
            Id = id;
        }
    }
}
