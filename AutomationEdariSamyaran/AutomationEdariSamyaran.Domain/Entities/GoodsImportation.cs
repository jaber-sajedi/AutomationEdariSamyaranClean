using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class GoodsImportation
    {
        [Key]
        public int Id { get; set; }
        public int IdGoodsImportation { get; set; }
        public DateTime CreateAt { get; set; }
        public int IdUnit { get; set; }
        public int IdPersonal { get; set; }
        public int IdSeller { get; set; }
        public int InvoiceNumber { get; set; }
        public int Id_afzilly { get; set; }
        public int NumberProducts { get; set; }
        public Boolean TemporaryDeletion { get; set; }

        public ICollection<Units> UnitUnits { get; set; }
        public ICollection<Personal> PersonalUnits { get; set; }
        public ICollection<Seller> Sellers { get; set; }
        public ICollection<CellarTafzilli> CellarTafzillis { get; set; }


    }
}
