using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_User
    {
        [Key]
        public int Id_User { get; set; }
        public string User_Name { get; set; }
        public string password { get; set; }
        public string Id_Personal { get; set; }
        public Boolean Temporary_Deletion { get; set; }

    }
}
