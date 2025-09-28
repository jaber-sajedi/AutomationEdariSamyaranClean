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
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }

        public int InvoiceNumber {get;set;}
        public int UserId { get; set; }

    }
}
