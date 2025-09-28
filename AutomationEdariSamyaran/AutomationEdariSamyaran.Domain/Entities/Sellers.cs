using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Seller
    {
        [Key]
        public int    id     { get; set; }
        public string? NameSeller   { get; set; }
        public string? AdressSeller { get; set; }
       [MaxLength(15)]
        public string? TellSeller   { get; set; }
        [MaxLength(12)]
        public string? MobileSeller { get; set; }

    }
}
