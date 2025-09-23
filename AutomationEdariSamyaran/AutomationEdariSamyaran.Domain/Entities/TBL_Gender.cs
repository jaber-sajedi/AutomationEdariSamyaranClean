using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Gender
    {
        [Key]
        public int ID_Gender { get; set; }
        public string Gender_Type { get; set; }
    }
}
