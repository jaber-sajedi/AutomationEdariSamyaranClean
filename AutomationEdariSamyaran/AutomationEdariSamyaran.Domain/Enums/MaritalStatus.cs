using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum MaritalStatus
    {
        [Display(Name = "مجرد")]
        Single = 1,
        [Display(Name = "متاهل")]
        Married = 2,
    }
}
