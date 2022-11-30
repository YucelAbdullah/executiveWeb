using Microsoft.AspNetCore.Mvc;

namespace executiveWeb.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
