using Microsoft.AspNetCore.Mvc;

namespace HocApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
