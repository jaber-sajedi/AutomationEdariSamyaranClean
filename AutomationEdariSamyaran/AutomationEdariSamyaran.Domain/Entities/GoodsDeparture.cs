using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class GoodsDeparture
    {
        [Key]
        public int Id { get; set; }
        public int IdGoodsDeparture { get; set; }
        public DateTime? CreateAt { get; set; }
        public int IdUnit { get; set; }
        public int IdUnitsmeasurement { get; set; }//واحد شمارش
        public int IdPersonal { get; set; }
        public int IdTafzilly { get; set; }
        public int NumberProducts { get; set; }//تعداد کالا
        public Boolean Deleted { get; set; }



        public ICollection<Units> Units { get; set; }
        public ICollection<Personal> Personals { get; set; }
        public ICollection<CellarTafzilli> Cellar_Tafzillis { get; set; }
        public ICollection<Unitsmeasurement> Units_measurements { get; set; }


    }
}
