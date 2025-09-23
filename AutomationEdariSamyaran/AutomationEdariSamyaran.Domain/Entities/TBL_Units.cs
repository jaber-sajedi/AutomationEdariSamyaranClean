using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
   public class TBL_Units
    {
        //[Index]
        //public int ID_Index { get; set; }

        [Key]
        [Required]
        public int ID_Unit { get; set; }

        public string UnitName { get; set; }

    }
}
