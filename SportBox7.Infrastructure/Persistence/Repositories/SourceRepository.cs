namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using SportBox7.Application.Features.Sources;
    using SportBox7.Domain.Models.Sources;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SourceRepository : DataRepository<Source>, ISourceRepository
    {
        public SourceRepository(SportBox7DbContext db)
            :base(db)
        {

        }
    }
}
