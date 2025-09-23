using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    [Index(nameof(ID_BackupPath), IsUnique = true)]
    public class TBL_BackupPath
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_BackupPath { get; set; }
        [MaxLength(500)]
        public string BackupPath { get; set; }
    }
}
