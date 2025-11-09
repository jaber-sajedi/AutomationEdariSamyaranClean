using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class CompleteWorkflowStepCommand
    {
        [Display(Name = "شناسه مرحله گردش کار")]
        public int WorkflowInstanceStepId { get; set; }

        [Display(Name = "شناسه انجام‌دهنده")]
        public int CompletedById { get; set; }
    }
}
