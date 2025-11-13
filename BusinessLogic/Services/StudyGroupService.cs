using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class StudyGroupService : IStudyGroupService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StudyGroupService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<УчебныеГруппы>> GetAll()
        {
            return await _repositoryWrapper.УчебныеГруппы.FindAll();
        }

        public async Task<УчебныеГруппы> GetById(int id)
        {
            var group = await _repositoryWrapper.УчебныеГруппы
                .FindByCondition(x => x.IdГруппы == id);
            return group.First();
        }

        public async Task Create(УчебныеГруппы model)
        {
            await _repositoryWrapper.УчебныеГруппы.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(УчебныеГруппы model)
        {
            _repositoryWrapper.УчебныеГруппы.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var group = await _repositoryWrapper.УчебныеГруппы
                .FindByCondition(x => x.IdГруппы == id);

            _repositoryWrapper.УчебныеГруппы.Delete(group.First());
            _repositoryWrapper.Save();
        }
    }
}