using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Authorize(Policy = "Reader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // GET api/protected/home
        [HttpGet]
        public IActionResult Home()
        {
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
