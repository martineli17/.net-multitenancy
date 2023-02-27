using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Multitenancy.Configuration;

namespace Multitenancy.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITenancyRepository _tenancyRepository;
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService, ITenancyRepository tenancyRepository)
        {
            _tokenService = tokenService;
            _tenancyRepository = tenancyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] Guid tenancyId, CancellationToken cancellationToken)
        {
            var tenancy = await _tenancyRepository.GetAsync(x => x.Id == tenancyId, cancellationToken);
            if (tenancy.Any())
            {
                var token = _tokenService.GenerateToken(tenancyId);
                return Ok(token);
            }

            return StatusCode(401);
        }
    }
}
