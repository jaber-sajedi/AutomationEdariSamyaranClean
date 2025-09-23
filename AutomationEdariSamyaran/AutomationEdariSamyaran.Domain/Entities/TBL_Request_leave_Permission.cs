using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Request_leave_Permission
    {
        [Key]
        public int ID_Request_Permission { get; set; }
        public int Counter { get; set; }
        public int Id_Request_leave { get; set; }
        public int Id_Personal { get; set; }
        public int Id_Rank { get; set; }
        public string Description { get; set; }

        [Display(Name = "وضعیت تایید")]
        public int Confirmation_status { get; set; }

        [Display(Name = "تاریخ تایید")]
        public string Date_of_Confirmation { get; set; }



        public ICollection<TBL_Request_leave> TBL_Request_leave { get; set; }
        public ICollection<TBL_Personal> TBL_Personal { get; set; }
        public ICollection<TBL_Organizational_Rank> TBL_Organizational_Rank { get; set; }



    }
}
