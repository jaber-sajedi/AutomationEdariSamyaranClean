using AutomationEdariSamyaran.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        IRepository<TBL_User> User { get; }
        IRepository<Greatadvice> Great_advice { get; }
        IRepository<letterSubject> letter_Subject { get; }
        IRepository<Units> Units { get; }
        IRepository<Gender> Gender { get; }
        IRepository<State> State { get; }
        IRepository<TBL_Cities> Cities { get; }
        IRepository<TBL_Degree_Education> Degree_Education { get; }
        IRepository<MaritalStatus> Marital_Status { get; }

        IRepository<Personal> Personal { get; }
        IRepository<CellarKoll> Cellar_Koll { get; }
        IRepository<CellarMoein> Cellar_Moein { get; }
        IRepository<CellarTafzilli> Cellar_Tafzilli { get; }
        IRepository<TBL_Seller> Seller { get; }
        IRepository<OrganizationalRank> Organizational_Rank { get; }
        IRepository<OrganizationalChart> Organizational_Chart { get; }
        IRepository<Unitsmeasurement> Units_measurement { get; }
        IRepository<GoodsImportation> Goods_Importation { get; }
        IRepository<Publicmessages> Public_messages { get; }
        IRepository<PublicMessagePermission> Public_Message_Permission { get; }
        IRepository<Requestleave> Request_leave { get; }
        IRepository<RequestLeavePermission> Request_leave_Permission { get; }
        IRepository<RankPermission> Rank_Permission { get; }
        IRepository<GoodsRequest> Goods_Request { get; }

        IRepository<TBL_Goods_Departure> Goods_Departure { get; }
        IRepository<PhoneBook> PhoneBook { get; }
        IRepository<DailyReminderTask> Daily_Reminder_Task { get; }
        IRepository<letterDraft> letter_Draft { get; }
        IRepository<TBL_Letter_Recepiant> Letter_Recepiant { get; }
        IRepository<Letters> Letters { get; }
        IRepository<ArchivesKoll> Archives_Koll { get; }
        IRepository<ArchivesMoein> Archives_Moein { get; }
        IRepository<ArchivesTafzilli> Archives_Tafzilli { get; }
        IRepository<ApplicationSetting> Application_Setting { get; }
        IRepository<User_Permission> User_Permission { get; }
       














        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
