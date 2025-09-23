using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Daily_Reminder_Task
    {
        [Key]
        public int ID_Not { get; set; }

        public int    Id_Persenel { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Reminder_date { get; set; }
        public string Reminder_Hour { get; set; }
        public string Reminder_text { get; set; }
        public Boolean Displayed { get; set; }

        public ICollection<TBL_Personal> tBL_Personals { get; set; }
    }
}
