using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Company_information
    {
        [Key]
        public int ID_Company_information { get; set; }
        public string CompanyName { get; set; }
        public string Date_Registration { get; set; }
        public int Number_Registration { get; set; }
        public int National_code { get; set; }
        public int Economic_code { get; set; }
        public int Postal_code{ get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite_Address { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set; }
        public string Fax_Number { get; set; }
        public byte[] Image { get; set; }
    }
}
