using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRoleAssignmentService
    {
        Task<List<НазначенияРолей>> GetAll();
        Task<НазначенияРолей> GetById(int id);
        Task Create(НазначенияРолей model);
        Task Update(НазначенияРолей model);
        Task Delete(int id);
    }
}