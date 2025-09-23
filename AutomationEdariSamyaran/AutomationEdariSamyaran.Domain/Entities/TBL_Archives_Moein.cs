using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Archives_Moein
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID_Moein { get; set; }
        public string Name_Moein { get; set; }
        public int Id_Koll { get; set; }
        public ICollection<TBL_Archives_Koll> ArchivesKolls { get; set; }
    }
}
