using ITI.Sauce.Models;

using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class HomeController : Controller
    {

       // DBContext dBContext = new DBContext();
        public RecipeRepository RecRepo;
        public UserRepository UserRepo;
        public VendorRepository VendorRepo;
        public RestaurantRepository RestaurantRepo;

        public HomeController(UserRepository _UserRepository, RecipeRepository _RecRepo, VendorRepository _VendorRepo
            , RestaurantRepository _RestaurantRepo)
        {
            RecRepo=new RecipeRepository(dBContext);
            UserRepo= _UserRepository;
            VendorRepo = _VendorRepo;
            RestaurantRepo = _RestaurantRepo;
        }
        public IActionResult Index()
        {
            ViewBag.RecipeCount=RecRepo.GetList().Count();
            ViewBag.UserCount=UserRepo.GetList().Count();
            ViewBag.VendorCount=VendorRepo.GetList().Count();
            ViewBag.ReataurantCount = RestaurantRepo.GetList().Count();

            return View(ViewBag);
        }
    }
}
