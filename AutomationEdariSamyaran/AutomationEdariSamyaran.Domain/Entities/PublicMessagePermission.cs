using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class PublicMessagePermission
    {
        [Key]
        public int Id { get; set; }
        public int IdMessagePermission { get; set; }
        public int IdPersonal { get; set; }


        public ICollection<Personal> TBL_Personals { get; set; }
    }
}
