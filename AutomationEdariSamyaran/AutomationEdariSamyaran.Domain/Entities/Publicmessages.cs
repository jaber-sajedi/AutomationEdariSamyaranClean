using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Publicmessages
    {
        [Key]
        public int Id { get; set; }
        public string? DateofRegistration { get; set; }
        public string? MessageSubject { get; set; }
        public string? MessageContent { get; set; }
        public string? IdPersenelSend { get; set; }
        public string? IdPersenelReceive { get; set; }
        public Boolean Displayed { get; set; }
        public string? DateofDisplayed { get; set; }
        public byte[]? AttachedFile { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }


        public ICollection<Personal>TBLPersonals { get; set; }
    }
}
