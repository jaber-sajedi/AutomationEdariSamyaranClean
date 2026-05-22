using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum LetterType
    {
        [Display(Name = "نامه های داخلی سازمانی")]
        Incoming = 1,
        [Display(Name = "نامه های بیرون سازمانی")]
        Outgoing = 2,
    }
}
