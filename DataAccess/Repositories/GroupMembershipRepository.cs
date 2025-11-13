using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class GroupMembershipRepository : RepositoryBase<ЧленствоВгруппах>, IGroupMembershipRepository
    {
        public GroupMembershipRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}