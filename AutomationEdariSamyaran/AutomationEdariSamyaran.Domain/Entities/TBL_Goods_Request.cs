using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Goods_Request
    {
        [Key]
        public int ID { get; set; }
        public int ID_Goods_Request { get; set; }
        public string Date_of_Registration { get; set; }
        public string Date_of_View { get; set; }
        public int Id_Personal_View { get; set; }//شخص مشاهده کننده
        public int Id_Unit { get; set; }
        public int Id_Units_measurement { get; set; }//واحد شمارش
        public int Id_Personal { get; set; }
        public int Id_Tafzilly { get; set; }
        public int Number_Products { get; set; }//تعداد کالا
        public Boolean Deleted { get; set; }



        public ICollection<TBL_Units> Unit_Units { get; set; }
        public ICollection<TBL_Personal> Personals { get; set; }
        public ICollection<TBL_Cellar_Tafzilli> Cellar_Tafzillis { get; set; }
        public ICollection<TBL_Units_measurement> Units_measurements { get; set; }

    }
}
