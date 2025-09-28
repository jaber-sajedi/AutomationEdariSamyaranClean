using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class ArchivesMoein
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string? Name { get; set; }
        // Foreign Key به Koll
        public int IdKoll { get; set; }
        [ForeignKey("IdKoll")]
        public ArchivesKoll? Koll { get; set; }
        public ICollection<ArchivesTafzilli>? Tafzillis { get; set; }
    }
}
