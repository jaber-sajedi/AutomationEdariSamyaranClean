using AutomationEdariSamyaran.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Units.Commands
{
   
    public class CreateUnitCommand : IRequest<bool>
    {
        public string UnitName { get; set; }
        public CreateUnitCommand(string unitName)
        {
            UnitName=unitName;
        }
    }
}
