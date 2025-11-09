using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
  public  class StartWorkflowInstanceCommand
    {
        public int WorkflowId { get; set; }
        public int InitiatorId { get; set; }
    }
}
