using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Workflow_Approvers
    {
        public int ID_WF_Approvers { get; set; }
        public int Id_Workflow { get; set; }
        public int Id_Persenel { get; set; }
        public Boolean Viewing_license { get; set; }
        public  string Viewing_license_Date { get; set; }
        public string Viewing_Description { get; set; }
        public Boolean Approval_license { get; set; }
        public string Approval_license_Date { get; set; }
        public string Approval_Description { get; set; }
        public Boolean Delete_license { get; set; }
        public string Delete_license_Date { get; set; }
        public string Delete_Description { get; set; }
        public Boolean Edit_license { get; set; }
        public string Edit_license_Date { get; set; }
        public string Edit_Description { get; set; }

        public ICollection<TBL_Work_Flow> Work_Flows { get; set; }
        public ICollection<TBL_Personal> Personals { get; set; }
    }
}
