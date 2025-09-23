using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_Personal
    {
        [Key]
        public int ID_Personal { get; set; }
        public int Id_Gender { get; set; }
        public string Frist_Name { get; set; }
        public string Last_Name { get; set; }
        public int Num_Shenasname { get; set; }
        public string Father_Name { get; set; }
        public double National_Code { get; set; }
        public string DateOf_Birth { get; set; }
        public int Id_State { get; set; }
        public int Id_City { get; set; }
        public int Id_Degree_Education { get; set; }
        public string FieldofStudy { get; set; }
        public int Id_Unit { get; set; }
        public int Id_Organ_Ranks { get; set; }
        public string Contract_Type { get; set; }
        public int Id_Marital_Status { get; set; }
        public int NumberOf_Children { get; set; }
        public string Insurance_Number { get; set; }
        public int Postal_code { get; set; }
        public string Start_Job { get; set; }
        public string End_Job { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Tell { get; set; }
        public string Mobile { get; set; }
        public Boolean Persenel_Active { get; set; }
        public byte[] Image { get; set; }

        public ICollection<TBL_Gender> tBL_Genders { get; set; }
        public ICollection<TBL_State> tBL_States { get; set; }
        public ICollection<TBL_Cities> tBL_Cities { get; set; }
        public ICollection<TBL_Degree_Education> tBL_Degree_Educations { get; set; }
        public ICollection<TBL_Units> TBL_Units { get; set; }
        public ICollection<TBL_Marital_Status> tBL_Marital_Status { get; set; }
        public ICollection<TBL_Organizational_Rank> TBL_Organizational_Ranks { get; set; }
    }
}
