using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class RequestLeavePermission
    {
        [Key]
        public int Id { get; set; }
        public int Counter { get; set; }
        public int IdRequestleave { get; set; }
        public int IdPersonal { get; set; }
        public int IdRank { get; set; }
        public string? Description { get; set; }

        [Display(Name = "وضعیت تایید")]
        public int Confirmationstatus { get; set; }

        [Display(Name = "تاریخ تایید")]
        public DateTime? DateofConfirmation { get; set; }



        public ICollection<Requestleave> TBLRequestleave { get; set; }
        public ICollection<Personal> TBLPersonal { get; set; }
        public ICollection<OrganizationalRank> TBLOrganizationalRank { get; set; }



    }
}
