using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Seller
    {
        [Key]
        public int    ID_Seller      { get; set; }
        public string Name_Seller   { get; set; }
        public string Adress_Seller { get; set; }
       [MaxLength(15)]
        public string Tell_Seller   { get; set; }
        [MaxLength(12)]
        public string Mobile_Seller { get; set; }

    }
}
