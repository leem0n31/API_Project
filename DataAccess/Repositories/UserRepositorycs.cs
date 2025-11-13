using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Пользователи>, IUserRepository
    {
        public UserRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}