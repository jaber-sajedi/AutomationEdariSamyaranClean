using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Command
{
    public record CreateWorkflowStepCommand(int WorkflowId, string Name, int Order, int? RoleId) : IRequest<int>;
}
