using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class ReplacementRequestRepository : RepositoryBase<ЗапросыНаЗамену>, IReplacementRequestRepository
    {
        public ReplacementRequestRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}