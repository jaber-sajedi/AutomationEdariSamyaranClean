using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Commands
{
    public class DeleteUnitCommand:IRequest<bool>
    {
        public int Id  { get; set; }

        public DeleteUnitCommand(int id)
        {
            Id = id;
        }
    }
}
