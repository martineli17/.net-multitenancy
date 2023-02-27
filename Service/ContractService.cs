using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class ContractService : IContractService
    {
        private readonly IUserService _userService;
        private readonly IContractRepository _contractRepository;

        public ContractService(IUserService userService, IContractRepository contractRepository)
        {
            _userService = userService;
            _contractRepository = contractRepository;
        }

        public async Task AddAsync(ContractAddDto contract, CancellationToken cancellationToken)
        {
            var tenancyId = _userService.GetTenancyId();
            var entity = new Contract(tenancyId, contract.Value);
            await _contractRepository.AddAsync(entity, cancellationToken);
        }

        public async Task<IEnumerable<Contract>> GetAllAsync(CancellationToken cancellationToken)
        {
            var tenancyId = _userService.GetTenancyId();
            return await _contractRepository.GetAsync(x => x.TenancyId == tenancyId, cancellationToken);
        }
    }
}
