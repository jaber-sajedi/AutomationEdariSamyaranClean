using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Public_Message_Permission
    {
        [Key]
        public int ID_Message { get; set; }
        public int Id_Message_Permission { get; set; }
        public int Id_Personal { get; set; }


        public ICollection<TBL_Personal> TBL_Personals { get; set; }
    }
}
