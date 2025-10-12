using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!; // نام سمت شغلی

        [MaxLength(200)]
        public string? Description { get; set; } // توضیح سمت
    }
}
