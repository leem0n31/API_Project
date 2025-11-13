using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDutyScheduleService
    {
        Task<List<РасписаниеДежурств>> GetAll();
        Task<РасписаниеДежурств> GetById(int id);
        Task Create(РасписаниеДежурств model);
        Task Update(РасписаниеДежурств model);
        Task Delete(int id);
    }
}