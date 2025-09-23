using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Cellar_Tafzilli
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Tafzilly { get; set; }
        public string Name_Tafzilly { get; set; }
        public int Id_Koll { get; set; }
        public int Id_Moein { get; set; }
        public int Id_Units_Measurement { get; set; }
        public ICollection<TBL_Cellar_Koll> tBL_Kolls { get; set; }
        public ICollection<TBL_Cellar_Moein> tBL_Moein { get; set; }
        public ICollection<TBL_Units_measurement> tBL_Units_measurement { get; set; }
    }
}
//////////////////////////////
// [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
//public DateTime LastAccessed { get; set; }