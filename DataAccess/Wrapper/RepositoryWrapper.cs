using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Proect1Context _repoContext;
        private IUserRepository _user;
        private IAbsenceRepository _absence;
        private IDutyScheduleRepository _dutySchedule;
        private IRoleRepository _role;
        private INotificationRepository _notification;
        private IStudyGroupRepository _studyGroup;
        private IGroupMembershipRepository _groupMembership;
        private IDutyDebtRepository _dutyDebt;
        private IReplacementRequestRepository _replacementRequest;
        private IRoleAssignmentRepository _roleAssignment;

        public IUserRepository Пользователи
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IAbsenceRepository Пропуски
        {
            get
            {
                if (_absence == null)
                {
                    _absence = new AbsenceRepository(_repoContext);
                }
                return _absence;
            }
        }

        public IDutyScheduleRepository РасписаниеДежурств
        {
            get
            {
                if (_dutySchedule == null)
                {
                    _dutySchedule = new DutyScheduleRepository(_repoContext);
                }
                return _dutySchedule;
            }
        }

        public IRoleRepository Роли
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }

        public INotificationRepository Уведомления
        {
            get
            {
                if (_notification == null)
                {
                    _notification = new NotificationRepository(_repoContext);
                }
                return _notification;
            }
        }

        public IStudyGroupRepository УчебныеГруппы
        {
            get
            {
                if (_studyGroup == null)
                {
                    _studyGroup = new StudyGroupRepository(_repoContext);
                }
                return _studyGroup;
            }
        }

        public IGroupMembershipRepository ЧленствоВгруппах
        {
            get
            {
                if (_groupMembership == null)
                {
                    _groupMembership = new GroupMembershipRepository(_repoContext);
                }
                return _groupMembership;
            }
        }

        public IDutyDebtRepository ДолгиПоДежурствам
        {
            get
            {
                if (_dutyDebt == null)
                {
                    _dutyDebt = new DutyDebtRepository(_repoContext);
                }
                return _dutyDebt;
            }
        }

        public IReplacementRequestRepository ЗапросыНаЗамену
        {
            get
            {
                if (_replacementRequest == null)
                {
                    _replacementRequest = new ReplacementRequestRepository(_repoContext);
                }
                return _replacementRequest;
            }
        }

        public IRoleAssignmentRepository НазначенияРолей
        {
            get
            {
                if (_roleAssignment == null)
                {
                    _roleAssignment = new RoleAssignmentRepository(_repoContext);
                }
                return _roleAssignment;
            }
        }

        public RepositoryWrapper(Proect1Context repositoryContext)
        {
            _repoContext = repositoryContext;
        }

       public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}