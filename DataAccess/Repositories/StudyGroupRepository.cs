using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class StudyGroupRepository : RepositoryBase<УчебныеГруппы>, IStudyGroupRepository
    {
        public StudyGroupRepository(Proect1Context repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}