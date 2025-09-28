using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum DegreeEducation
    {
        [Display(Name = "زیردیپلم")]
        Undergraduate,
        [Display(Name = "دیپلم")]
        Diploma,
        [Display(Name = "فوق دیپلم")]
        AssociatesDegree,
        [Display(Name = "کارشناسی")]
        BachelorsDegree,
        [Display(Name = "کارشناسی ارشد")]
        MastersDegree,
        [Display(Name = "دکتری")]
        Doctorate,
    }
}
