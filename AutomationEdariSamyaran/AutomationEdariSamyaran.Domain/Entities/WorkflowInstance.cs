using AutomationEdariSamyaran.Domain.Entities ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class WorkflowInstance
    {
        [Key]
        public int Id { get; set; }
        public int WorkflowId { get; set; }
        [ForeignKey(nameof(WorkflowId))]
        public Workflow Workflow { get; set; } = null!;

        public int PersonalId { get; set; }
        [ForeignKey(nameof(PersonalId))]
        public Personal Personal { get; set; } = null!;

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
    }

}
