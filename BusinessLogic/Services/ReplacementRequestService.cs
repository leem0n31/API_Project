using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class ReplacementRequestService : IReplacementRequestService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ReplacementRequestService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ЗапросыНаЗамену>> GetAll()
        {
            return await _repositoryWrapper.ЗапросыНаЗамену.FindAll();
        }

        public async Task<ЗапросыНаЗамену> GetById(int id)
        {
            var request = await _repositoryWrapper.ЗапросыНаЗамену
                .FindByCondition(x => x.IdЗапроса == id);
            return request.First();
        }

        public async Task Create(ЗапросыНаЗамену model)
        {
            await _repositoryWrapper.ЗапросыНаЗамену.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(ЗапросыНаЗамену model)
        {
            _repositoryWrapper.ЗапросыНаЗамену.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var request = await _repositoryWrapper.ЗапросыНаЗамену
                .FindByCondition(x => x.IdЗапроса == id);

            _repositoryWrapper.ЗапросыНаЗамену.Delete(request.First());
            _repositoryWrapper.Save();
        }
    }
}