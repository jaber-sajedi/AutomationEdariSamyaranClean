using AutomationEdariSamyaran.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }
        public int PersonalCode { get; set; }
        public Gender Gender { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public int NumShenasname { get; set; }
        public string? FatherName { get; set; }
        public double NationalCode { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int? IdState { get; set; }
        [ForeignKey("IdState")]
        public State? State { get; set; }

        public int? IdCity { get; set; }
        [ForeignKey("IdCity")]
        public City? City { get; set; }

        public DegreeEducation IdDegreeEducation { get; set; }
        public string? FieldofStudy { get; set; }

         
        public int IdUnit { get; set; }
        [ForeignKey("IdUnit")]
        public Units Units { get; set; }

        public int IdOrganRanks { get; set; }
        [ForeignKey("IdOrganRanks")]
        public OrganizationalRank organizationalRank { get; set; }

        public string? ContractType { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int NumberOfChildren { get; set; }
        public string? InsuranceNumber { get; set; }
        public int Postalcode { get; set; }
        public string? StartJob { get; set; }
        public string? EndJob { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Tell { get; set; }
        public string? Mobile { get; set; }
        public Boolean PersenelActive { get; set; }
        public byte[] Image { get; set; }
        public Boolean TemporaryDeletion { get; set; }



        public ICollection<PhoneBook>? PhoneBooks { get; set; } = new List<PhoneBook>();
        public ICollection<UserPermission>? UserPermissions { get; set; } = new List<UserPermission>();
        public ICollection<DailyReminderTask> DailyReminders { get; set;} = new List<DailyReminderTask>();
    }
}
