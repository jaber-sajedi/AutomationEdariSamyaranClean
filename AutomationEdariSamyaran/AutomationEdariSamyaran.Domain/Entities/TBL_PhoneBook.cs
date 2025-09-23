using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_PhoneBook
    {
        [Key]
        public int ID_PhoneBook { get; set; }
        public int Id_Personal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Local_phone1 { get; set; }
        public string Local_phone2 { get; set; }
        public string Work_phone1 { get; set; }
        public string Work_phone2 { get; set; }
        public string Home_phone1 { get; set; }
        public string Home_phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Fax { get; set; }
        public string Job_Title { get; set; }
        public string Workplace_Name { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Address_Workplace { get; set; }
        public string Address_Home { get; set; }
        public string Description { get; set; }

        public  ICollection<TBL_Personal> TblPersonals { get; set; }
    }


   
}
