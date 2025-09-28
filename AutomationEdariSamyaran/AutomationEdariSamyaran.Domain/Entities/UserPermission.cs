 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Entities
{
    public class UserPermission
    {
        [Key]
        public int id { get; set; }
        // Foreign Key به Personal
        public int IdPersonal { get; set; }
        [ForeignKey("IdPersonal")]
        public Personal? Personal { get; set; }

        #region Base Settings
        public Boolean UserSettings { get; set; }
        public Boolean UnitsInformation { get; set; }
        public Boolean CompanyInfo { get; set; }
        public Boolean BackupRoot { get; set; }
        public Boolean BackupRestore { get; set; }
        public Boolean OrganizationalRank { get; set; }
        public Boolean OrganizationalChart { get; set; }
        #endregion

        #region Personal
        public Boolean Personallist { get; set; }
        public Boolean PersonalReport { get; set; }
        public Boolean RequestLeavemanagement { get; set; }
        public Boolean RequestList { get; set; }
        #endregion

        #region letter
        public Boolean letterSendList { get; set; }
        public Boolean lettersDraft { get; set; }
        public Boolean letterSubject { get; set; }
        #endregion

        #region Archive
        public Boolean KollArchives { get; set; }
        public Boolean MoeinArchives { get; set; }
        public Boolean Archives { get; set; }
        #endregion

        #region Seller && Goods 


        public Boolean Seller { get; set; }
        public Boolean UnitsMeasurement { get; set; }
        public Boolean KolGoods { get; set; }
        public Boolean MoeinGoods { get; set; }
        public Boolean Goods { get; set; }
        public Boolean GoodsImportation { get; set; }
        public Boolean GoodsRequests { get; set; }
        public Boolean GoodsDeparture { get; set; }
        public Boolean GoodsImpReport { get; set; }
        public Boolean GoodsCircReport { get; set; }
        public Boolean ProductRequestMessage { get; set; }

        #endregion


        #region Request leave

        public Boolean RequestLeave { get; set; }

        public Boolean RequestConfirmation { get; set; }
        public Boolean GoodsRequest { get; set; }
        public Boolean Publicmessages { get; set; }

        #endregion
    }
}
