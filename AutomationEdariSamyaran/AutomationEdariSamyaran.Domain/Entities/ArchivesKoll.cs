using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class ArchivesKoll
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ArchivesMoein>? Moeins { get; set; }
        public ICollection<ArchivesTafzilli>? Tafzillis { get; set; }
    }
}
