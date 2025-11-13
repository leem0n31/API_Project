using Domain.Models;

namespace Domain.Interfaces
{
    public interface INotificationService
    {
        Task<List<Уведомления>> GetAll();
        Task<Уведомления> GetById(int id);
        Task Create(Уведомления model);
        Task Update(Уведомления model);
        Task Delete(int id);
    }
}