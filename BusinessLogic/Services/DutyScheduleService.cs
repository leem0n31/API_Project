using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class DutyScheduleService : IDutyScheduleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DutyScheduleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<РасписаниеДежурств>> GetAll()
        {
            return await _repositoryWrapper.РасписаниеДежурств.FindAll();
        }

        public async Task<РасписаниеДежурств> GetById(int id)
        {
            var schedule = await _repositoryWrapper.РасписаниеДежурств
                .FindByCondition(x => x.IdРасписания == id);
            return schedule.First();
        }

        public async Task Create(РасписаниеДежурств model)
        {
            await _repositoryWrapper.РасписаниеДежурств.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(РасписаниеДежурств model)
        {
            _repositoryWrapper.РасписаниеДежурств.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var schedule = await _repositoryWrapper.РасписаниеДежурств
                .FindByCondition(x => x.IdРасписания == id);

            _repositoryWrapper.РасписаниеДежурств.Delete(schedule.First());
            _repositoryWrapper.Save();
        }
    }
}