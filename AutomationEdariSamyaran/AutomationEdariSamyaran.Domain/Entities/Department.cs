using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SectionId { get; set; }
      //  public Section Section { get; set; } = null!;
       // public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
