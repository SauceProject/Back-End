using Microsoft.AspNetCore.Mvc;

namespace ITI.Sauce.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
