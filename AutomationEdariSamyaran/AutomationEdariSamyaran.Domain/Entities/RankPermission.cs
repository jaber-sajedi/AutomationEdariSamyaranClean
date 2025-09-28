using AutomationEdariSamyaran.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class RankPermission
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int IdOrganRank { get; set; }
        public int IdOrganRankView { get; set; }
        public string? OrganChartTree { get; set; }


        public ICollection<OrganizationalRank> tBL_Organizationals { get; set; }


    }
}
