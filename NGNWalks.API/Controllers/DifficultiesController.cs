using Microsoft.AspNetCore.Mvc;

namespace NGNWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultiesController : Controller
    {
        public DifficultiesController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
