using AutomationEdariSamyaran.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query
{
    public record GetWorkflowStepsByWorkflowIdQuery(int WorkflowId) : IRequest<List<WorkflowStepDto>>;
}
