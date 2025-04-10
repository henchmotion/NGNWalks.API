using Microsoft.AspNetCore.Mvc;

namespace NGNWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
