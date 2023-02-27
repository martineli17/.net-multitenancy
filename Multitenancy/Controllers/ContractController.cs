using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Multitenancy.Controllers
{
    [Route("api/contract")]
    [ApiController]
    [Authorize]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContractAddDto request, CancellationToken cancellationToken)
        {
            await _contractService.AddAsync(request, cancellationToken);
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _contractService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
    }
}
