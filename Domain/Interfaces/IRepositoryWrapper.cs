
namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository Пользователи { get; }
        IAbsenceRepository Пропуски { get; }
        IDutyScheduleRepository РасписаниеДежурств { get; }
        IRoleRepository Роли { get; }
        INotificationRepository Уведомления { get; }
        IStudyGroupRepository УчебныеГруппы { get; }
        IGroupMembershipRepository ЧленствоВгруппах { get; }
        IDutyDebtRepository ДолгиПоДежурствам { get; }
        IReplacementRequestRepository ЗапросыНаЗамену { get; }
        IRoleAssignmentRepository НазначенияРолей { get; }
        Task Save();
    }
}