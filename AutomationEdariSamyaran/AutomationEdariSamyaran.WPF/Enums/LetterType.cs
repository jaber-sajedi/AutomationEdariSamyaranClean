using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Enums
{
    public enum LetterType
    {
        [Display(Name = "نامه های داخلی سازمانی")]
        Internal_Letter = 1,
        [Display(Name = "نامه های بیرون سازمانی")]
        External_Letter = 2,
    }
}
