using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Command
{
    public record StartWorkflowInstanceCommand(int WorkflowId, int InitiatorId) : IRequest<int>;
}
