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
            var claimsIdentity = (System.Security.Claims.ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;   

            ViewBag.RecipeCount=RecRepo.GetList().Count();
            ViewBag.UserCount=UserRepo.GetList().Count();
            ViewBag.VendorCount = VendorRepo.GetList().Count();
            ViewBag.ReataurantCount = RestaurantRepo.GetList().Count();
            if (this.User.HasClaim(c => c.Value == "Vendor"))
            {
                var Vendor = VendorRepo.GetList().FirstOrDefault(i => i.ID == userId);
                //if (Vendor != null)
                //ViewBag.Flag = Vendor.IsDeleted;
                
            }

            // return new ObjectResult(ViewBag);
            return View();
        }

        
    }
}
