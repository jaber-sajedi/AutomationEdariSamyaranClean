using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Unitsmeasurement
    {
        [Key]
        public int Id { get; set; }
        public string? NameMeasurement { get; set; }
        public ICollection<CellarTafzilli>? Tafzillis { get; set; }
    }
}
