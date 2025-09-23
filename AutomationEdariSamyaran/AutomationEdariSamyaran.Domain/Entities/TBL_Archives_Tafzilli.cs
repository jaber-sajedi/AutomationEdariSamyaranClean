using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
	public class TBL_Archives_Tafzilli
	{
		#region properties
		[Key]
	     public int ID_Tafzilly { get; set; }
		public string Name_Tafzilly { get; set; }
		public string DateOfRegister { get; set; }	
		public int Id_Koll { get; set; }
		public int Id_Moein { get; set; }
		public Boolean IsDeleted { get; set; }
		public byte[] Attached_File { get; set; }
		public string File_Name { get; set; }
		public string File_Type { get; set; }
		#endregion

		#region relation
		public ICollection<TBL_Archives_Koll> ArchivesKolls { get; set; }
		public ICollection<TBL_Archives_Moein> ArchivesMoeins { get; set; }
		#endregion





	}
}
