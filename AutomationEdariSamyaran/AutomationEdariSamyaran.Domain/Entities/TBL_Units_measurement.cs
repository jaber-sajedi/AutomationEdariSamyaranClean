using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Units_measurement
    {
        [Key]
        public int ID_Units_Measurement { get; set; }
        public string Name_Measurement { get; set; }
    }
}
