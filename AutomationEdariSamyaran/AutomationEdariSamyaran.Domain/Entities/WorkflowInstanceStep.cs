using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class WorkflowInstanceStep
    {
        [Key]
        public int Id { get; set; }
        public int WorkflowInstanceId { get; set; }
        [ForeignKey(nameof(WorkflowInstanceId))]
        public WorkflowInstance WorkflowInstance { get; set; } = null!;

        public int WorkflowStepId { get; set; }
        [ForeignKey(nameof(WorkflowStepId))]
        public WorkflowStep WorkflowStep { get; set; } = null!;

        public int? AssignedToId { get; set; }
        [ForeignKey(nameof(AssignedToId))]
        public Personal? AssignedTo { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
    }

}
