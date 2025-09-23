using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Work_Flow
    {
        [Key]
        public int ID_Workflow { get; set; }
        public string Name_Workflow { get; set; }
    }
}
