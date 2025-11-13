using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class RoleAssignmentRepository : RepositoryBase<НазначенияРолей>, IRoleAssignmentRepository
    {
        public RoleAssignmentRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}