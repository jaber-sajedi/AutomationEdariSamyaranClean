using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Marital_Status
    {
        [Key]
        public int ID_Marital_Status { get; set; }
        public string Marital_Status { get; set; }
    }
}
