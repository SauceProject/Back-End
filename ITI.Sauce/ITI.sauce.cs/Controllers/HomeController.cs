using ITI.Sauce.Models;

using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class HomeController : Controller
    {

        
        public RecipeRepository RecRepo;
        public UserRepository UserRepo;
        public VendorRepository VendorRepo;
        public RestaurantRepository RestaurantRepo;

        public HomeController(UserRepository _UserRepository, RecipeRepository _RecRepo, VendorRepository _VendorRepo
            , RestaurantRepository _RestaurantRepo)
        {
            RecRepo = _RecRepo;
            UserRepo = _UserRepository;
            VendorRepo = _VendorRepo;
            RestaurantRepo = _RestaurantRepo;
        }
        [Authorize(Roles = "Admin,Vendor")]
        public IActionResult Index()
        {
            ViewBag.RecipeCount=RecRepo.GetList().Count();
            ViewBag.UserCount=UserRepo.GetList().Count();
            ViewBag.VendorCount=VendorRepo.GetList().Count();
            ViewBag.ReataurantCount = RestaurantRepo.GetList().Count();

            // return new ObjectResult(ViewBag);
            return View();
        }
    }
}
