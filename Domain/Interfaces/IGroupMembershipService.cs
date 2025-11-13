using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGroupMembershipService
    {
        Task<List<ЧленствоВгруппах>> GetAll();
        Task<ЧленствоВгруппах> GetById(int id);
        Task Create(ЧленствоВгруппах model);
        Task Update(ЧленствоВгруппах model);
        Task Delete(int id);
    }
}