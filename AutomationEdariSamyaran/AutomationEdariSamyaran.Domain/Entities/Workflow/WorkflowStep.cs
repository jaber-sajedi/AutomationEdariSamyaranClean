using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities.Workflow
{
    public class WorkflowStep
    {
        [Key]
        public int Id { get; set; }
        public int WorkflowId { get; set; }
        [ForeignKey(nameof(WorkflowId))]
        public Workflow Workflow { get; set; } = null!;

        public string Name { get; set; } = null!;
        public int Order { get; set; } // ترتیب مراحل
        public int? RoleId { get; set; } // چه نقشی این مرحله را انجام می‌دهد
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }

}
