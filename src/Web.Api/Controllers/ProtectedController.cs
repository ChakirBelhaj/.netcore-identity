using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data;
using Web.Api.Infrastructure.Identity;

namespace Web.Api.Controllers
{
    [Authorize(Policy = "Reader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public ProtectedController(UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        // GET api/protected/home
        [HttpGet]
        public IActionResult Home()
        {
            var identityId = User.Claims.First(x => x.Type == "id").Value;

            var user = _appDbContext.Users.First(x => x.IdentityId == identityId);
            //          _userRepository.

            string test = "";
            foreach (var claim in User.Claims)
            {
                test += " ";
                test += claim.Type;
                test += " = ";
                test += claim.Value;
                test += " ; ";
            }

            return new OkObjectResult(new { result = test });
        }
    }
}