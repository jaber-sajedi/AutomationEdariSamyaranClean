using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public  class TBL_Degree_Education
    {
        [Key] 
        public int ID_Degree_Education { get; set; }
        public string Degree_Education { get; set; }
    }
}
