using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class NotificationRepository : RepositoryBase<Уведомления>, INotificationRepository
    {
        public NotificationRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}