using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Greatadvice
    {
        [Key]
        public int Id { get; set; }
        public string? Writername { get; set; }
        public string? Advice { get; set; }
    }
}
