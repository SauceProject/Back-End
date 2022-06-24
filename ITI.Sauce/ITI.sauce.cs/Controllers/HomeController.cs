using ITI.Sauce.Repositorie;
using ITI.Sauce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class HomeController : Controller
    {
        public RecipeRepository RecRepo;
        public UserRepository UserRepo;
        public VendorRepository VendorRepo;
        public HomeController()
        {
            RecRepo=new RecipeRepository();
            UserRepo=new UserRepository();
            VendorRepo = new VendorRepository();
        }

        public IActionResult Index()
        {
            ViewBag.RecipeCount=RecRepo.GetList().Count();
            ViewBag.UserCount=UserRepo.GetList().Count();
            ViewBag.VendorCount=VendorRepo.GetList().Count();
            return View(ViewBag);
        }
    }
}
