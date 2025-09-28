using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum letter_Type
    {
        [Display(Name = "نامه های داخلی سازمانی")]
        Internal_Letter = 1,
        [Display(Name = "نامه های بیرون سازمانی")]
        External_Letter = 2,
    }
}
