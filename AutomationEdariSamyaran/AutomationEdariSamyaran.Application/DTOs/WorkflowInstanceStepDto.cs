using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.DTOs
{
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
