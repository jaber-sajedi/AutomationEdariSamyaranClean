using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units_measurement.Commands
{
    public class UpdateUnitMeasurementCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateUnitMeasurementCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
