using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(IMongoContext context) : base(context)
        {
        }

        protected override string GetCollectionName() => "Contract";
    }
}
