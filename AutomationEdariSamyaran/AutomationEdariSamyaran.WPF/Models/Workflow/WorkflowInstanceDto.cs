using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class WorkflowInstanceDto
    {
        public int Id { get; set; }                 // شناسه نمونه جریان کاری
        public int WorkflowId { get; set; }         // شناسه Workflow اصلی
        public string? Status { get; set; }         // وضعیت فعلی نمونه، مثل "InProgress" یا "Completed"
        public int InitiatorId { get; set; }        // شناسه کاربر شروع‌کننده جریان
        public DateTime? StartDate { get; set; }    // تاریخ شروع نمونه
        public DateTime? EndDate { get; set; }      // تاریخ پایان نمونه (در صورت تکمیل)
    }
}
