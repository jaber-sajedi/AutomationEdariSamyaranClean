using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.DTOs
{
    public class WorkflowInstanceDto
    {
        public int Id { get; set; }
        public int WorkflowId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
    }
}
