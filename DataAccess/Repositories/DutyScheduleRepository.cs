using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class DutyScheduleRepository : RepositoryBase<РасписаниеДежурств>, IDutyScheduleRepository
    {
        public DutyScheduleRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}