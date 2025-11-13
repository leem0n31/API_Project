using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RoleAssignmentService : IRoleAssignmentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RoleAssignmentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<НазначенияРолей>> GetAll()
        {
            return await _repositoryWrapper.НазначенияРолей.FindAll();
        }

        public async Task<НазначенияРолей> GetById(int id)
        {
            var assignment = await _repositoryWrapper.НазначенияРолей
                .FindByCondition(x => x.IdНазначения == id);
            return assignment.First();
        }

        public async Task Create(НазначенияРолей model)
        {
            await _repositoryWrapper.НазначенияРолей.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(НазначенияРолей model)
        {
            _repositoryWrapper.НазначенияРолей.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var assignment = await _repositoryWrapper.НазначенияРолей
                .FindByCondition(x => x.IdНазначения == id);

            _repositoryWrapper.НазначенияРолей.Delete(assignment.First());
            _repositoryWrapper.Save();
        }
    }
}