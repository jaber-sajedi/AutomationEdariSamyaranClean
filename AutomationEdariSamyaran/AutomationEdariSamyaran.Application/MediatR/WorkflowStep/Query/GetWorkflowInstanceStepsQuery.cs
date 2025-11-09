using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.MediatR.WorkflowStep.Query
{
    namespace AutomationEdariSamyaran.Application.MediatR.WorkflowInstance.Query
    {
        // Query برای گرفتن مراحل یک Instance
        public record GetWorkflowInstanceStepsQuery(int WorkflowInstanceId) : IRequest<List<WorkflowInstanceStepDto>>;

        // DTO برای پاسخ به کاربر
        public class WorkflowInstanceStepDto
        {
            public int Id { get; set; }
            public string StepName { get; set; } = string.Empty;
            public bool IsCompleted { get; set; }
            public int? AssignedToId { get; set; }
            public DateTime? CompletedAt { get; set; }
            public int Order { get; set; }
        }
    }
}
