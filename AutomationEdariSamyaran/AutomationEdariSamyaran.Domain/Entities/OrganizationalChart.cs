using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace YourNamespace
    {

        public class OrganizationalChart
        {
            [Key]
            public int Id { get; set; }

            // Foreign Key به OrganizationalRank
            public int IdOrgan_Rank { get; set; }
            [ForeignKey("IdOrgan_Rank")]
            public OrganizationalRank? Rank { get; set; }

            public bool HasAFather { get; set; }

            public int? IdFather { get; set; }

            [ForeignKey("IdFather")]
            public OrganizationalChart? Father { get; set; }

            public ICollection<OrganizationalChart>? Children { get; set; }
        }
    }
}