using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Great_advice
    {
        [Key]
        public int ID_Greatadvice { get; set; }
        public string Writer_name { get; set; }
        public string Advice { get; set; }
    }
}
