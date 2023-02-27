using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class TenancyService : ITenancyService
    {
        private readonly ITenancyRepository _tenancyRepository;

        public TenancyService(ITenancyRepository tenancyRepository)
        {
            _tenancyRepository = tenancyRepository;
        }

        public async Task<Tenancy> AddAsync(TenancyAddDto tenancy, CancellationToken cancellationToken)
        {
            var entity = new Tenancy(tenancy.Name);
            await _tenancyRepository.AddAsync(entity, cancellationToken);
            return entity;
        }
    }
}
