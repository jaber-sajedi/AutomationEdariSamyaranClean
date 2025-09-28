using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class CellarTafzilli
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdKoll { get; set; }
        [ForeignKey("IdKoll")]
        public CellarKoll? Koll { get; set; }

        public int IdMoein { get; set; }
        [ForeignKey("IdMoein")]
        public CellarMoein? Moein { get; set; }

        public int IdUnitsMeasurement { get; set; }
        [ForeignKey("IdUnitsMeasurement")]
        public Unitsmeasurement? UnitsMeasurement { get; set; }
    }
}