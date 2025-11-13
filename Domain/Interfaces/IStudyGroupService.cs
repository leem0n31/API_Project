using Domain.Models;

namespace Domain.Interfaces
{
    public interface IStudyGroupService
    {
        Task<List<УчебныеГруппы>> GetAll();
        Task<УчебныеГруппы> GetById(int id);
        Task Create(УчебныеГруппы model);
        Task Update(УчебныеГруппы model);
        Task Delete(int id);
    }
}