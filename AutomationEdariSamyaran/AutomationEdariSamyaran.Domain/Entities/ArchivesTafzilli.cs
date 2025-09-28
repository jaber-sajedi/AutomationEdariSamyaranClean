using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class ArchivesTafzilli
    {
        [Key]
        public int Id { get; set; }
        public string? NameTafzilly { get; set; }
        public string? CreateAt { get; set; }

        // Foreign Key به Koll
        public int IdKoll { get; set; }
        [ForeignKey("IdKoll")]
        public ArchivesKoll? Koll { get; set; }

        // Foreign Key به Moein
        public int IdMoein { get; set; }
        [ForeignKey("IdMoein")]
        public ArchivesMoein? Moein { get; set; }

        public bool TemporaryDeletion { get; set; }
        public byte[]? AttachedFile { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
    }
}
