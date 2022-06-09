using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("/")]
    public class AppController : ControllerBase
    {
        public AppController() { }

        [HttpGet]
        public string Index()
        {
            return "Authentication Service v1.0";
        }

    }
}
