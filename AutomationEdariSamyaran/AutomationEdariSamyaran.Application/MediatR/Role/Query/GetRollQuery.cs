using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Query
{
    public record GetRollQuery():IRequest<List<Domain.Entities.Role>>;
   
}
