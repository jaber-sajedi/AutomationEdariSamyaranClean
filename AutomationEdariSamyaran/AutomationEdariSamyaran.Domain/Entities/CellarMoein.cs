using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class CellarMoein
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string? Name { get; set; }

        public int IdKoll { get; set; }
        [ForeignKey("IdKoll")]
        public CellarKoll? Koll { get; set; }

        public ICollection<CellarTafzilli>? Tafzillis { get; set; }
    }
}
