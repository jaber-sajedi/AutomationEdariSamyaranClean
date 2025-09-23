using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_letter_Draft
    {
        [Key]
        public int    ID_Draft_letters { get; set; }

        public string letters_Tittel { get; set; }
        public byte[] Attached_File  { get; set; }
        public string File_Name      { get; set; }
        public string File_Type { get; set; }
    }
}
