using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class AbsenceService : IAbsenceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AbsenceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Пропуски>> GetAll()
        {
            return await _repositoryWrapper.Пропуски.FindAll();
        }

        public async Task<Пропуски> GetById(int id)
        {
            var absence = await _repositoryWrapper.Пропуски
                .FindByCondition(x => x.IdПропуска == id);
            return absence.First();
        }

        public async Task Create(Пропуски model)
        {
            await _repositoryWrapper.Пропуски.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Пропуски model)
        {
            _repositoryWrapper.Пропуски.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var absence = await _repositoryWrapper.Пропуски
                .FindByCondition(x => x.IdПропуска == id);

            _repositoryWrapper.Пропуски.Delete(absence.First());
            _repositoryWrapper.Save();
        }
    }
}