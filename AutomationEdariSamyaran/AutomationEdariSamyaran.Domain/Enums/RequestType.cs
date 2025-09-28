using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum RequestType
    {
        [Display(Name = "روزانه")]
        Day = 1,
        [Display(Name = "ساعتی")]
        Hour = 2,
    }
}
