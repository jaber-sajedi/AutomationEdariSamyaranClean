using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Importation_Goods
    {
        [Key]//واردات کالا
        public int ID_Importation { get; set; }
        public string Entry_Date { get; set; }

        public int Invoice_Number {get;set;}

    }
}
