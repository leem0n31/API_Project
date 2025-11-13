using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRoleService
    {
        Task<List<Роли>> GetAll();
        Task<Роли> GetById(int id);
        Task Create(Роли model);
        Task Update(Роли model);
        Task Delete(int id);
    }
}