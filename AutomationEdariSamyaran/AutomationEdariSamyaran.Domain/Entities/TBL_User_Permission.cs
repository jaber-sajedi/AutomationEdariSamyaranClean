 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class TBL_User_Permission
    {
        [Key]
        public int ID { get; set; }
        public string Id_Personal { get; set; }

        #region Base Settings
        public Boolean User_Settings { get; set; }
        public Boolean Units_Information { get; set; }
        public Boolean Company_info { get; set; }
        public Boolean Backup_Root { get; set; }
        public Boolean Backup_Restore { get; set; }
        public Boolean Organizational_Rank { get; set; }
        public Boolean Organizational_Chart { get; set; }
        #endregion

        #region Personal
        public Boolean Personal_list { get; set; }
        public Boolean Personal_report { get; set; }
        public Boolean Request_leave_management { get; set; }
        public Boolean Request_List { get; set; }
        #endregion

        #region letter
        public Boolean letter_Send_List { get; set; }
        public Boolean letters_Draft { get; set; }
        public Boolean letter_Subject { get; set; }
        #endregion

        #region Archive
        public Boolean Koll_Archives { get; set; }
        public Boolean Moein_Archives { get; set; }
        public Boolean Archives { get; set; }
        #endregion

        #region Seller && Goods 


        public Boolean Seller { get; set; }
        public Boolean Units_measurement { get; set; }
        public Boolean Kol_Goods { get; set; }
        public Boolean Moein_Goods { get; set; }
        public Boolean Goods { get; set; }
        public Boolean Goods_Importation { get; set; }
        public Boolean Goods_requests { get; set; }
        public Boolean Goods_Departure { get; set; }
        public Boolean Goods_Imp_Report { get; set; }
        public Boolean Goods_Circ_Report { get; set; }
        public Boolean Product_Request_Message { get; set; }

        #endregion


        #region Request leave

        public Boolean Request_leave { get; set; }

        public Boolean Request_Confirmation { get; set; }
        public Boolean Goods_Request { get; set; }
        public Boolean Public_messages { get; set; }

        #endregion
    }
}
