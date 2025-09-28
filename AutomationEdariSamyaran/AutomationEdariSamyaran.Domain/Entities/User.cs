using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? User_Name { get; set; }
        public string? password { get; set; }
        public string? IdPersonal { get; set; }
        public Boolean TemporaryDeletion { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
