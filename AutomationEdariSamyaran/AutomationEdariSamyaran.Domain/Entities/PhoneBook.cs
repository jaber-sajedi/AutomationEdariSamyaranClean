using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class PhoneBook
    {
        [Key]
        public int Id { get; set; }


        // Foreign Key به Personal
        public int IdPersonal { get; set; }
        [ForeignKey("IdPersonal")]
        public Personal? Personal { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Localphone1 { get; set; }
        public string? Localphone2 { get; set; }
        public string? Workphone1 { get; set; }
        public string? Workphone2 { get; set; }
        public string? Homephone1 { get; set; }
        public string? Homephone2 { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Fax { get; set; }
        public string? JobTitle { get; set; }
        public string? WorkplaceName { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? AddressWorkplace { get; set; }
        public string? AddressHome { get; set; }
        public string? Description { get; set; }

      
    }


   
}
