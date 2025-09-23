using AutomationEdariSamyaran.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Rank_Permission
    {
        [Key]
        public int ID_Rank_Permission { get; set; }
        public int Number { get; set; }
        public int Id_Organ_Rank { get; set; }
        public int Id_Organ_Rank_View { get; set; }
        public string Organ_Chart_Tree { get; set; }


        public ICollection<TBL_Organizational_Rank> tBL_Organizationals { get; set; }


    }
}
