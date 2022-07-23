using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.sauce.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeRepository RecipeRepo;
        private readonly CategoryRepository CatRepo;
        private readonly UnitOfWork UnitOfWork;
        private readonly VendorRepository VendorRepo;
        private readonly RestaurantRepository RestRepo;

        public RecipeController(RecipeRepository _RecipeRepo, UnitOfWork _unitOfWork, 
            VendorRepository _VendorRepo, CategoryRepository _CatRepo, RestaurantRepository _RestRepo)
        {
            this.RecipeRepo = _RecipeRepo;
            UnitOfWork = _unitOfWork;
            VendorRepo = _VendorRepo;
            CatRepo = _CatRepo;
            RestRepo = _RestRepo;

        }
        //[Authorize(Roles = "Admin,User,Vendor")]
        public IActionResult Get(string NameAr = null, string NameEN = null,
            string orderBy = null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20 , int RestaurantID = 0,int CategoryID=0)
        {
            var data = RecipeRepo.Get(
                NameAr, NameEN, orderBy, ImageUrl,VideoUrl,
                isAscending,Price, rdate, category,pageIndex,pageSize , RestaurantID, CategoryID );
            ViewBag.Resturant = RestaurantID;
            ViewBag.Category = CategoryID;
            return View(data);
        }
        //[Authorize(Roles = "Admin,Vendor")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 4)
        {

            var result = RecipeRepo.Search(pageIndex, pageSize);
            return View("Get", result);

        }
        //[Authorize(Roles = "Admin,Vendor")]
        [HttpGet]
        public IActionResult Add(string? returnUrl, int? ResturantId)
        {
            ViewBag.ReturnUrl = returnUrl;
            IEnumerable<SelectListItem> Categories = 
                GetCateogriesNames(CatRepo.GetCategoriesDropDown());
            IEnumerable<SelectListItem> Restaurants = 
                GetRestaurantNames(RestRepo.GetCRestaurantDropDown());

            ViewBag.Categories = Categories;
            ViewBag.Restaurants = Restaurants;
            
            return View(new RecipeEditViewModel { RestaurantID = ResturantId });
        }
        private IEnumerable<SelectListItem> GetCateogriesNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
        }

        private IEnumerable<SelectListItem> GetRestaurantNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
        }
        //[Authorize(Roles = "Admin,Vendor")]
        [HttpPost]
        public IActionResult Add(RecipeEditViewModel model , string? returnUrl = null)
        {

            string? bookUploadUrl = "/Content/Uploads/Recipe/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Recipe", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;

            RecipeRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");
        }

       

        [HttpGet]
        public IActionResult Update(int ID)
        {
            IEnumerable<SelectListItem> Categories = GetCateogriesNames(CatRepo.GetCategoriesDropDown());
            IEnumerable<SelectListItem> Restaurants = GetRestaurantNames(RestRepo.GetCRestaurantDropDown());

            ViewBag.Categories = Categories;
            ViewBag.Restaurants = Restaurants;
            var recipe = RecipeRepo.GetOne(ID);
            ViewBag.CurrentRecipe = recipe;
            return View();
        }
        [HttpPost]
        public IActionResult Update(RecipeEditViewModel model, int ID)
        {
            string? bookUploadUrl = "/Content/Uploads/Recipe/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Recipe", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;
            RecipeRepo.Update(model, ID);
            UnitOfWork.Save();
            return RedirectToAction("Get");
           
        }
        public IActionResult Remove(RecipeEditViewModel model, int ID , int RestaurantID)
        {
            RecipeRepo.Remove(model,ID);
            UnitOfWork.Save();
            //return RedirectToAction("Get" , RestaurantID);
            if (RestaurantID > 0)
            {
                return RedirectToAction("Get", new { RestaurantID = RestaurantID });
            }
            else
            {
                return RedirectToAction("Get");
            }

        }
        public IActionResult AcceptRecipe(RecipeEditViewModel model, int ID , int RestaurantID)
        {
           
            RecipeRepo.AcceptRecipe(model, ID);
            UnitOfWork.Save();
            //return RedirectToAction("Get", RestaurantID);
            if (RestaurantID > 0)
            {
                return RedirectToAction("Get",new { RestaurantID = RestaurantID } );
            }
            else 
            {
                return RedirectToAction("Get");
            }
        }



        

    }
}
