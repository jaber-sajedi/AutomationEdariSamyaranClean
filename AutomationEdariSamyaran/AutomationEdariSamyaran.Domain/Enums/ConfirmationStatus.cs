using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Enums
{
    public enum ConfirmationStatus
    {
        [Display(Name = "ثبت اولیه")]
        InitialRegistration = 0,
        [Display(Name = "درحال بررسی")]
        Pending = 1,
        [Display(Name = "تایید شد")]
        Confirmed = 2,
        [Display(Name = "تایید نشد")]
        NotConfirmed = 3
    }
}
