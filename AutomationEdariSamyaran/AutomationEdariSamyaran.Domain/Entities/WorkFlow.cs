using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class WorkFlow
    {
        [Key]
        public int Id { get; set; }
        public string? NameWorkflow { get; set; }
    }
}
