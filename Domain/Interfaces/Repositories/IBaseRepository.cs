using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> query, CancellationToken cancellationToken);
    }
}
