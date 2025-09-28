using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class WorkflowApprovers
    {
        public int Id { get; set; }
        public int IdWorkflow { get; set; }
        public int IdPersenel { get; set; }
        public Boolean Viewinglicense { get; set; }
        public  DateTime? ViewinglicenseDate { get; set; }
        public string? ViewingDescription { get; set; }
        public Boolean ApprovalLicense { get; set; }
        public DateTime? ApprovalLicenseDate { get; set; }
        public string? ApprovalDescription { get; set; }
        public Boolean DeleteLicense { get; set; }
        public DateTime? DeleteLicenseDate { get; set; }
        public string? DeleteDescription { get; set; }
        public Boolean EditLicense { get; set; }
        public DateTime? EditLicenseDate { get; set; }
        public string? EditDescription { get; set; }

        public ICollection<WorkFlow> WorkFlows { get; set; }
        public ICollection<Personal> Personals { get; set; }
    }
}
