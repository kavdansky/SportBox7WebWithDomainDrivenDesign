namespace SportBox7.Infrastructure.Persistence.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Contracts;
    using Domain.Common;

    internal abstract class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected readonly SportBox7DbContext db;

        protected DataRepository(SportBox7DbContext db) => this.db = db;


        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.db.Update(entity);

            await this.db.SaveChangesAsync(cancellationToken);
        }

        protected IQueryable<TEntity> All() => this.db.Set<TEntity>();
    }
}
