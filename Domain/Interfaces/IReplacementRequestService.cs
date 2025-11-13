using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReplacementRequestService
    {
        Task<List<ЗапросыНаЗамену>> GetAll();
        Task<ЗапросыНаЗамену> GetById(int id);
        Task Create(ЗапросыНаЗамену model);
        Task Update(ЗапросыНаЗамену model);
        Task Delete(int id);
    }
}