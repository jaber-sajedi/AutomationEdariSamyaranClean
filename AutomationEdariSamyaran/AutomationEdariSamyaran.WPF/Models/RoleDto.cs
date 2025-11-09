using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Display(Name = "نام نقش")]
        public string? Name { get; set; }
    }
}
