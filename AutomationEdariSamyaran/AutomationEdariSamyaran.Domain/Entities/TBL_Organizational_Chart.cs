using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Organizational_Chart
    {
        [Key]
        public int ID_Organ_Chart { get; set; }
        public int Id_Organ_Rank { get; set; }
        public Boolean has_a_Father { get; set; }
        public int Id_Father { get; set; }

        public ICollection<TBL_Organizational_Rank> Organ_Ranks { get; set; }
    }
}
