using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Commands
{
    public class UpdateUnitCommand : IRequest<bool>
    {
        public int Id { get; set; }        
        public string Name { get; set; }   

        public UpdateUnitCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
