using System.ComponentModel.DataAnnotations;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Application_Setting
    {
        [Key]
        public int ID { get; set; }

        public int TimeForMessageDelete { get; set; }
    }
}
