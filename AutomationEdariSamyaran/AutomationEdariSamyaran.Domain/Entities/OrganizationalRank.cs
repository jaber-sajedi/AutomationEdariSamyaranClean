using AutomationEdariSamyaran.Domain.Entities.YourNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class OrganizationalRank
    {
        [Key] // سمت
        public int Id { get; set; }
        public string? OrganRank { get; set; }

        // Navigation property برای دسترسی به نمودارهای سازمانی با این سمت
        public ICollection<OrganizationalChart>? Charts { get; set; }
        public ICollection<Personal>? Personals { get; set; } = new List<Personal>();

    }
}
