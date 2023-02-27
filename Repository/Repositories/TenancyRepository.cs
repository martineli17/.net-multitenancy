using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class TenancyRepository : BaseRepository<Tenancy>, ITenancyRepository
    {
        public TenancyRepository(IMongoContext context) : base(context)
        {
        }

        protected override string GetCollectionName() => "Tenancy";
    }
}
