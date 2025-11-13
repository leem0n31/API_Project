using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class DutyDebtService : IDutyDebtService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DutyDebtService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ДолгиПоДежурствам>> GetAll()
        {
            return await _repositoryWrapper.ДолгиПоДежурствам.FindAll();
        }

        public async Task<ДолгиПоДежурствам> GetById(int id)
        {
            var debt = await _repositoryWrapper.ДолгиПоДежурствам
                .FindByCondition(x => x.IdДолга == id);
            return debt.First();
        }

        public async Task Create(ДолгиПоДежурствам model)
        {
            await _repositoryWrapper.ДолгиПоДежурствам.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ДолгиПоДежурствам model)
        {
            _repositoryWrapper.ДолгиПоДежурствам.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var debt = await _repositoryWrapper.ДолгиПоДежурствам
                .FindByCondition(x => x.IdДолга == id);

            _repositoryWrapper.ДолгиПоДежурствам.Delete(debt.First());
            _repositoryWrapper.Save();
        }
    }
}