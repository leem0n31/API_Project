using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Роли>> GetAll()
        {
            return await _repositoryWrapper.Роли.FindAll();
        }

        public async Task<Роли> GetById(int id)
        {
            var role = await _repositoryWrapper.Роли
                .FindByCondition(x => x.IdРоли == id);
            return role.First();
        }

        public async Task Create(Роли model)
        {
            await _repositoryWrapper.Роли.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Роли model)
        {
            _repositoryWrapper.Роли.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var role = await _repositoryWrapper.Роли
                .FindByCondition(x => x.IdРоли == id);

            _repositoryWrapper.Роли.Delete(role.First());
            _repositoryWrapper.Save();
        }
    }
}