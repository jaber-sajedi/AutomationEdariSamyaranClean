using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class CreateWorkflowStepCommand
    {
        public int WorkflowId { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public int? RoleId { get; set; }
    }
}
