 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Application.DTOs
{
    public class WorkflowStepDto
    {
        public int Id { get; set; }
        public int WorkflowId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public RoleDto? Role { get; set; }
    }
}
