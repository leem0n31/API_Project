using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class NotificationService : INotificationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NotificationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Уведомления>> GetAll()
        {
            return await _repositoryWrapper.Уведомления.FindAll();
        }

        public async Task<Уведомления> GetById(int id)
        {
            var notification = await _repositoryWrapper.Уведомления
                .FindByCondition(x => x.IdУведомления == id);
            return notification.First();
        }

        public async Task Create(Уведомления model)
        {
            await _repositoryWrapper.Уведомления.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Уведомления model)
        {
            _repositoryWrapper.Уведомления.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var notification = await _repositoryWrapper.Уведомления
                .FindByCondition(x => x.IdУведомления == id);

            _repositoryWrapper.Уведомления.Delete(notification.First());
            _repositoryWrapper.Save();
        }
    }
}