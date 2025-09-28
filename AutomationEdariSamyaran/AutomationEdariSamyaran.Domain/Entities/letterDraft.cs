using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class letterDraft
    {
        [Key]
        public int    Id { get; set; }
        public string? lettersTittel { get; set; }
        public byte[]? AttachedFile  { get; set; }
        public string? FileName      { get; set; }
        public string? FileType { get; set; }
    }
}
