using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Letters
    {
        [Key]
        public int ID_letter { get; set; }
        public string letter_Number { get; set; }
        public string Date_of_Registration { get; set; }
        public string Date_of_View { get; set; }

        /// /////////////////////////////////
        // Internal=0 External=1
        public int letter_Type { get; set; }
        public int Id_letter_Subject { get; set; }
        public int ID_Send_letter { get; set; }
        public int ID_Receive_letters { get; set; }
        public byte[] Attached_File { get; set; }
      //  public byte[] Attached_FileAfterSign { get; set; }
        public string File_Name { get; set; }
        public string File_Type { get; set; }

        public  Boolean Temporary_Deletion { get; set; }
        public ICollection<TBL_letter_Subject> TblLetterSubjects { get; set; }

        
    }
    
 
}
