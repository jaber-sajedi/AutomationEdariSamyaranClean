using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Cellar_Koll
    {
        [Key]
        public int ID_Koll { get; set; }
        public string Name_Koll { get; set; }
    }
}
