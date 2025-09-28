using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key به State
        public int Id_State { get; set; }
        [ForeignKey("Id_State")]
        public State? State { get; set; }

        public string? Name { get; set; }
    }
}
