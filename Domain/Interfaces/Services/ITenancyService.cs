using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ITenancyService
    {
        Task<Tenancy> AddAsync(TenancyAddDto tenancy, CancellationToken cancellationToken);
    }
}
