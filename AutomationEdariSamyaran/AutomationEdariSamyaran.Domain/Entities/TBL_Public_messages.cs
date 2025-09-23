using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Public_messages
    {
        [Key]
        public int ID_Public_messages { get; set; }
        public string Date_of_Registration { get; set; }
        public string Message_Subject { get; set; }
        public string Message_Content { get; set; }
        public string Id_Persenel_Send { get; set; }
        public string Id_Persenel_Receive { get; set; }
        public Boolean Displayed { get; set; }
        public string Date_of_Displayed { get; set; }
        public byte[] Attached_File { get; set; }
        public string File_Name { get; set; }
        public string File_Type { get; set; }


        public ICollection<TBL_Personal>TBL_Personals { get; set; }
    }
}
