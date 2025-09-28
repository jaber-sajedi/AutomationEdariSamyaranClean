using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class LetterRecepiant
    {
        [Key]
        public int Id { get; set; }
        public string? RecepiantName { get; set; }

        public ICollection<Letters>? Letters { get; set; }
    }
}
