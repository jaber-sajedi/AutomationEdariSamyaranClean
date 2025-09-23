using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Goods_Importation
    {
        [Key]
        public int ID { get; set; }
        public int ID_Goods_Importation { get; set; }
        public string Date_of_Registration { get; set; }
        public int Id_Unit { get; set; }
        public int Id_Personal { get; set; }
        public int Id_Seller { get; set; }
        public int Invoice_Number { get; set; }
        public int Id_Tafzilly { get; set; }
        public int Number_Products { get; set; }
        public Boolean Deleted { get; set; }

        public ICollection<TBL_Units> Unit_Units { get; set; }
        public ICollection<TBL_Personal> Personal_Units { get; set; }
        public ICollection<TBL_Seller> tBL_Sellers { get; set; }
        public ICollection<TBL_Cellar_Tafzilli> tBL_Cellar_Tafzillis { get; set; }


    }
}
