using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Letter_Recepiant
    {
        [Key]
        public int ID_letter_Recepiant { get; set; }
        public string Recepiant_Name { get; set; }
    }
}
