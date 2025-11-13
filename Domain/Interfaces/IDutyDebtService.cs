using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDutyDebtService
    {
        Task<List<ДолгиПоДежурствам>> GetAll();
        Task<ДолгиПоДежурствам> GetById(int id);
        Task Create(ДолгиПоДежурствам model);
        Task Update(ДолгиПоДежурствам model);
        Task Delete(int id);
    }
}