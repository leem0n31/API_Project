using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class GroupMembershipService : IGroupMembershipService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMembershipService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ЧленствоВгруппах>> GetAll()
        {
            return await _repositoryWrapper.ЧленствоВгруппах.FindAll();
        }

        public async Task<ЧленствоВгруппах> GetById(int id)
        {
            var membership = await _repositoryWrapper.ЧленствоВгруппах
                .FindByCondition(x => x.IdЧленства == id);
            return membership.First();
        }

        public async Task Create(ЧленствоВгруппах model)
        {
            await _repositoryWrapper.ЧленствоВгруппах.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ЧленствоВгруппах model)
        {
            _repositoryWrapper.ЧленствоВгруппах.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var membership = await _repositoryWrapper.ЧленствоВгруппах
                .FindByCondition(x => x.IdЧленства == id);

            _repositoryWrapper.ЧленствоВгруппах.Delete(membership.First());
            _repositoryWrapper.Save();
        }
    }
}