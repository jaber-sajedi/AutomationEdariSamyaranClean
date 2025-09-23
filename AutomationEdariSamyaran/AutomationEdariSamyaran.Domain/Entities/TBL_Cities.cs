using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Cities
    {
        [Key]
        public int ID_Cities { get; set; }
        public int Id_State { get; set; }
        public string Name_City { get; set; }

        public ICollection<TBL_State> tBL_States { get; set; }
    }
}
