using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Cellar_Moein
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
         
        public int ID_Moein { get; set; }
        public string Name_Moein { get; set; }
        public int Id_Koll { get; set; }
        public ICollection<TBL_Cellar_Koll>  tBL_Kolls  { get; set; }
    }
}
