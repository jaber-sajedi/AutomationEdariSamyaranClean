
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Request_leave
    {
        [Key]
        public int ID_Request_leave { get; set; }
        public int Id_Personal { get; set; }
        public int Request_Type { get; set; }
        public string Date_of_Registration { get; set; }
        public string Date_of_Registration_hourly { get; set; }
        public string Start_hourly_leave { get; set; }
        public string End_hourly_leave { get; set; }
        public string Start_Daily_leave { get; set; }
        public string End_Daily_leave { get; set; }
        public string Description_of_leave { get; set; }

        [Display(Name = "وضعیت مرخصی")]
        public int Leave_Status { get; set; }
        public string Date_of_Aapproval { get; set; }

        [Display(Name ="کد ثبت کننده مرخصی")]
        public int Id_Registrant_Personal_code { get; set; }

        public Boolean Temporary_Deletion { get; set; }

        public ICollection<TBL_Personal>tBL_Personals { get; set; }
    }


   

}
