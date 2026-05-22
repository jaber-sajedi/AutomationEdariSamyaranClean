using AutomationEdariSamyaran.Application.MediatR.CompleteWorkflowStep.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.CompleteWorkflowStep.Command
{
    public record CompleteWorkflowStepCommand(int WorkflowInstanceStepId, int CompletedById) : IRequest<bool>;
}

