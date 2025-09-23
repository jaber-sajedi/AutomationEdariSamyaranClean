using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_State
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_State { get; set; }
        public string Name_State { get; set; }
    }
}
