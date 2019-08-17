using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    // GET api/protected/home
    [HttpGet]
    public IActionResult Test()
    {
      var result = "hello world";

      return new OkObjectResult(new { result });
    }
  }
}