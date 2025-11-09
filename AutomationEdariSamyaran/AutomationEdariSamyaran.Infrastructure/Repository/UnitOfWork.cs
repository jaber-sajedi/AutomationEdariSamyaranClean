using AutomationEdariSamyaran.Domain.Entities;
using AutomationEdariSamyaran.Domain.Interfaces;
using AutomationEdariSamyaran.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        private IRepository<TBL_User>? _User;
        public IRepository<TBL_User> User => _User ??= new Repository<TBL_User>(_context);
        private IRepository<Greatadvice>? _Great_advice;
        public IRepository<Greatadvice> Great_advice => _Great_advice ??= new Repository<Greatadvice>(_context);
        private IRepository<letterSubject>? _letter_Subject;
        public IRepository<letterSubject> letter_Subject => _letter_Subject ??= new Repository<letterSubject>(_context);
        private IRepository<Units>?  _Units;
        public IRepository<Units> Units => _Units ??= new Repository<Units>(_context);
        private IRepository<Gender>? _Gender;
        public IRepository<Gender> Gender => _Gender ??= new Repository<Gender>(_context);
        private IRepository<State>? _State;
        public IRepository<State> State => _State ??= new Repository<State>(_context);
        private IRepository<TBL_Cities>? _Cities;
        public IRepository<TBL_Cities> Cities => _Cities ??= new Repository<TBL_Cities>(_context);
        private IRepository<TBL_Degree_Education>? _Degree_Education;
        public IRepository<TBL_Degree_Education> Degree_Education => _Degree_Education ??= new Repository<TBL_Degree_Education>(_context);
        private IRepository<MaritalStatus>? _Marital_Status;
        public IRepository<MaritalStatus> Marital_Status => _Marital_Status ??= new Repository<MaritalStatus>(_context);
        private IRepository<Personal>? _Personal;
        public IRepository<Personal> Personal => _Personal ??= new Repository<Personal>(_context);

        private IRepository<CellarKoll>? _Cellar_Koll;
        public IRepository<CellarKoll> Cellar_Koll => _Cellar_Koll ??= new Repository<CellarKoll>(_context);

        private IRepository<CellarMoein>? _Cellar_Moein;
        public IRepository<CellarMoein> Cellar_Moein => _Cellar_Moein ??= new Repository<CellarMoein>(_context);
        private IRepository<CellarTafzilli>? _Cellar_Tafzilli;
        public IRepository<CellarTafzilli> Cellar_Tafzilli => _Cellar_Tafzilli ??= new Repository<CellarTafzilli>(_context);
        private IRepository<TBL_Seller>? _Seller;
        public IRepository<TBL_Seller> Seller => _Seller ??= new Repository<TBL_Seller>(_context);
        private IRepository<OrganizationalRank>? _Organizational_Rank;
        public IRepository<OrganizationalRank> Organizational_Rank => _Organizational_Rank ??= new Repository<OrganizationalRank>(_context);
        private IRepository<OrganizationalChart>? _Organizational_Chart;
        public IRepository<OrganizationalChart> Organizational_Chart => _Organizational_Chart ??= new Repository<OrganizationalChart>(_context);
        private IRepository<Unitsmeasurement>? _Units_measurement;
        public IRepository<Unitsmeasurement> Units_measurement => _Units_measurement ??= new Repository<Unitsmeasurement>(_context);
        private IRepository<GoodsImportation>? _Goods_Importation;
        public IRepository<GoodsImportation> Goods_Importation => _Goods_Importation ??= new Repository<GoodsImportation>(_context);
        private IRepository<Publicmessages>? _Public_messages;
        public IRepository<Publicmessages> Public_messages => _Public_messages ??= new Repository<Publicmessages>(_context);
        private IRepository<PublicMessagePermission>? _Public_Message_Permission;
        public IRepository<PublicMessagePermission> Public_Message_Permission => _Public_Message_Permission ??= new Repository<PublicMessagePermission>(_context);
        private IRepository<Requestleave>? _Request_leave;
        public IRepository<Requestleave> Request_leave => _Request_leave ??= new Repository<Requestleave>(_context);
        private IRepository<RequestLeavePermission>? _Request_leave_Permission;
        public IRepository<RequestLeavePermission> Request_leave_Permission => _Request_leave_Permission ??= new Repository<RequestLeavePermission>(_context);
        private IRepository<RankPermission>? _Rank_Permission;
        public IRepository<RankPermission> Rank_Permission => _Rank_Permission ??= new Repository<RankPermission>(_context);
        private IRepository<GoodsRequest>? _Goods_Request;
        public IRepository<GoodsRequest> Goods_Request => _Goods_Request ??= new Repository<GoodsRequest>(_context);
        private IRepository<TBL_Goods_Departure>? _Goods_Departure;
        public IRepository<TBL_Goods_Departure> Goods_Departure => _Goods_Departure ??= new Repository<TBL_Goods_Departure>(_context);
        private IRepository<PhoneBook>? _PhoneBook;
        public IRepository<PhoneBook> PhoneBook => _PhoneBook ??= new Repository<PhoneBook>(_context);
        private IRepository<DailyReminderTask>? _Daily_Reminder_Task;
        public IRepository<DailyReminderTask> Daily_Reminder_Task => _Daily_Reminder_Task ??= new Repository<DailyReminderTask>(_context);
        private IRepository<letterDraft>? _letter_Draft;
        public IRepository<letterDraft> letter_Draft => _letter_Draft ??= new Repository<letterDraft>(_context);
        private IRepository<TBL_Letter_Recepiant>? _Letter_Recepiant;
        public IRepository<TBL_Letter_Recepiant> Letter_Recepiant => _Letter_Recepiant ??= new Repository<TBL_Letter_Recepiant>(_context);
        private IRepository<Letters>? _Letters;
        public IRepository<Letters> Letters => _Letters ??= new Repository<Letters>(_context);
        private IRepository<ArchivesKoll>? _Archives_Koll;
        public IRepository<ArchivesKoll> Archives_Koll => _Archives_Koll ??= new Repository<ArchivesKoll>(_context);
        private IRepository<ArchivesMoein>? _Archives_Moein;
        public IRepository<ArchivesMoein> Archives_Moein => _Archives_Moein ??= new Repository<ArchivesMoein>(_context);
        private IRepository<ArchivesTafzilli>? _Archives_Tafzilli;
        public IRepository<ArchivesTafzilli> Archives_Tafzilli => _Archives_Tafzilli ??= new Repository<ArchivesTafzilli>(_context);
 
        private IRepository<User_Permission>? _User_Permission;
        public IRepository<User_Permission> User_Permission => _User_Permission ??= new Repository<User_Permission>(_context);
        private IRepository<ApplicationSetting>? _Application_Setting;
        public IRepository<ApplicationSetting> Application_Setting => _Application_Setting ??= new Repository<ApplicationSetting>(_context);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
