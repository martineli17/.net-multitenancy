using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Multitenancy.Controllers
{
    [Route("api/tenancy")]
    [ApiController]
    public class TenancyController : ControllerBase
    {
        private readonly ITenancyService _tenancyService;

        public TenancyController(ITenancyService tenancyService)
        {
            _tenancyService = tenancyService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TenancyAddDto request, CancellationToken cancellationToken)
        {
            var tenancy = await _tenancyService.AddAsync(request, cancellationToken);
            return StatusCode(201, tenancy);
        }
    }
}
