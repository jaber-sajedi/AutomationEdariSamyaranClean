 
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.Workflow.Query
{
    public record GetWorkflowsQuery() : IRequest<List<Domain.Entities.Workflow.Workflow>>;
}
