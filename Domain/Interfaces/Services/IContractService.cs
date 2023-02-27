using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IContractService
    {
        Task AddAsync(ContractAddDto contract, CancellationToken cancellationToken);
        Task<IEnumerable<Contract>> GetAllAsync(CancellationToken cancellationToken);
    }
}
