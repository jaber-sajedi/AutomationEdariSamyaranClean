using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class DailyReminderTask
    {
        [Key]
        public int Id { get; set; }

        public int IdPersonal { get; set; }
        [ForeignKey("IdPersonal")]
        public Personal? Personal { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Title { get; set; }
        public DateTime Reminderdate { get; set; }
        public TimeSpan ReminderHour { get; set; }
        public string? Remindertext { get; set; }
        public Boolean Displayed { get; set; }

    
    }
}
