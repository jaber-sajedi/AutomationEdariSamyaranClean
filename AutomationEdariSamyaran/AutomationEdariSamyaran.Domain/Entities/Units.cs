using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
   public class Units
    {
        //[Index]
        //public int ID_Index { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }

        public string? UnitName { get; set; }

    }
}
