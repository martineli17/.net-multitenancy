using Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoContext _context;
        private readonly IMongoCollection<TEntity> _collection;  

        public BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.MongoDataBase.GetCollection<TEntity>(GetCollectionName());
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> query, CancellationToken cancellationToken)
        {
            return await _collection.Find(query).ToListAsync(cancellationToken);
        }

        protected abstract string GetCollectionName();
    }
}
