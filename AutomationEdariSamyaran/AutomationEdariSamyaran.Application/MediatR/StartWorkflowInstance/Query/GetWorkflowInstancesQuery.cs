using AutomationEdariSamyaran.Domain.Entities.Workflow;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.StartWorkflowInstance.Query
{
    public record GetWorkflowInstancesQuery(int WorkflowId) : IRequest<List<WorkflowInstance>>;
}
