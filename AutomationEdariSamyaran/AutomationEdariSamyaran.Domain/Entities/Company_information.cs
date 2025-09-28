using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Company_information
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? DateRegistration { get; set; }
        public int NumberRegistration { get; set; }
        public int NationalCode { get; set; }
        public int EconomicCode { get; set; }
        public int PostalCode{ get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? WebSiteAddress { get; set; }
        public string? Tell1 { get; set; }
        public string? Tell2 { get; set; }
        public string? FaxNumber { get; set; }
        public byte[]? Image { get; set; }
    }
}
