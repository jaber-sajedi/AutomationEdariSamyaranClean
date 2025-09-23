using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_letter_Subject
    {
        [Key]
        public int ID_letter_Subject { get; set; }
        public string Subject_Name { get; set; }
    }
}
