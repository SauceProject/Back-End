using System.Security.Claims;
using ITI.Sauce.Models;

using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
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
            if (this.User.HasClaim(c => c.Value == "Admin"))
            {
                ViewBag.RecipeCount=RecRepo.GetList().Count();
                ViewBag.UserCount=UserRepo.GetList().Count();
                ViewBag.VendorCount=VendorRepo.GetList().Count();
                ViewBag.ReataurantCount = RestaurantRepo.GetList().Count();

            }
            else
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                ViewBag.ReataurantCount = RestaurantRepo.GetList().Where(v=>v.Vendor_ID ==userId).Count();



            }

            // return new ObjectResult(ViewBag);
            return View();
        }

        
    }
}
