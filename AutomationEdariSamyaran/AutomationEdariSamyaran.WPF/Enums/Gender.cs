using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Enums
{
    public enum Gender
    {
        [Display(Name = "مرد")]
        Man = 1,
        [Display(Name = "زن")]
        woman = 2,
    }
}
