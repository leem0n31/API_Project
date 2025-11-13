using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Пользователи>> GetAll()
        {
            return await _repositoryWrapper.Пользователи.FindAll();
        }

        public async Task<Пользователи> GetById(int id)
        {
            var user = await _repositoryWrapper.Пользователи
                .FindByCondition(x => x.IdПользователя == id);
            return user.First();
        }

        public async Task Create(Пользователи model)
        {
            await _repositoryWrapper.Пользователи.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Пользователи model)
        {
            _repositoryWrapper.Пользователи.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Пользователи
                .FindByCondition(x => x.IdПользователя == id);

            _repositoryWrapper.Пользователи.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}