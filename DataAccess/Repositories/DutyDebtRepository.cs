using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class DutyDebtRepository : RepositoryBase<ДолгиПоДежурствам>, IDutyDebtRepository
    {
        public DutyDebtRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}