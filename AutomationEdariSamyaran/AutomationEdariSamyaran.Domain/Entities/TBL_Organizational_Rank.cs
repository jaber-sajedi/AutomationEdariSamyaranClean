using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Organizational_Rank
    {
        [Key]//سمت
        public int ID_Organ_Rank { get; set; }
        public string  Organ_Rank { get; set; }
    }
}
