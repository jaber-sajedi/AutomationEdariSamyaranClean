using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class DraftLetter
    {
        [Key]
        public int    Id { get; set; }

        public string? Tittel { get; set; }
        public byte[]? File  { get; set; }
        public string? FileName      { get; set; }
    }
}
