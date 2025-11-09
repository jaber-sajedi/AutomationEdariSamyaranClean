using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Role.Command
{
    public record UpdateRoleCommand(int Id, string Name) : IRequest<bool>;
}
