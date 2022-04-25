using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("/")]
    public class AppController : ControllerBase
    {
        public AppController() { }

        [HttpGet]
        public string Index()
        {
            return "Welcome to AuthenticationService v1.0!";
        }

    }
}
