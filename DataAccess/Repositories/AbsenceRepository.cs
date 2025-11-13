using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class AbsenceRepository : RepositoryBase<Пропуски>, IAbsenceRepository
    {
        public AbsenceRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}