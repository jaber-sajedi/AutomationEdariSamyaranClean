using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class GoodsRequest
    {
        [Key]
        public int Id { get; set; }
        public int IdGoodsRequest { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? DateofView { get; set; }
        public int IdPersonalView { get; set; }//شخص مشاهده کننده
        public int IdUnit { get; set; }
        public int IdUnitsmeasurement { get; set; }//واحد شمارش
        public int IdPersonal { get; set; }
        public int IdTafzilly { get; set; }
        public int NumberProducts { get; set; }//تعداد کالا
        public Boolean TemporaryDeletion { get; set; }



        public ICollection<Domain.Entities.Units> Units { get; set; }
        public ICollection<Personal> Personals { get; set; }
        public ICollection<CellarTafzilli> CellarTafzillis { get; set; }
        public ICollection<Unitsmeasurement> Unitsmeasurements { get; set; }

    }
}
