using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class RoleRepository : RepositoryBase<Роли>, IRoleRepository
    {
        public RoleRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}