using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAbsenceService
    {
        Task<List<Пропуски>> GetAll();
        Task<Пропуски> GetById(int id);
        Task Create(Пропуски model);
        Task Update(Пропуски model);
        Task Delete(int id);
    }
}