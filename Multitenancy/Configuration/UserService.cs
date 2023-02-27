using Domain.Interfaces.Services;

namespace Multitenancy.Configuration
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _acessor;
        public UserService(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }
       
        public Guid GetTenancyId()
        {
            return Guid.Parse(_acessor.HttpContext.User.Claims.First(x => x.Type == "tenancy_id").Value);
        }
    }
}
