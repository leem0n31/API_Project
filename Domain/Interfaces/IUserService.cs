using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<Пользователи>> GetAll();
        Task<Пользователи> GetById(int id);
        Task Create(Пользователи model);
        Task Update(Пользователи model);
        Task Delete(int id);
    }
}