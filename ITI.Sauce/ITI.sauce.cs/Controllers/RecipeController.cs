using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeRepository RecipeRepo;
        private readonly UnitOfWork UnitOfWork;
        private readonly VendorRepository VendorRepo;
        public RecipeController(RecipeRepository _RecipeRepo, UnitOfWork _unitOfWork, VendorRepository _VendorRepo)
        {
           // DBContext dBContext = new DBContext();
            this.RecipeRepo = _RecipeRepo;
            UnitOfWork = _unitOfWork;
            VendorRepo = _VendorRepo;
        }
        [Authorize(Roles = "Admin,User,Vendor")]
        public ViewResult Get(string NameAr = null, string NameEN = null,
            string orderBy = null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20)
        {
            var data = RecipeRepo.Get(
                NameAr, NameEN, orderBy, ImageUrl,VideoUrl,
                isAscending,Price, rdate, category,pageIndex,pageSize);
            return View(data);
        }
        [Authorize(Roles = "Admin,Vendor")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = RecipeRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [Authorize(Roles = "Admin,Vendor")]
        [HttpGet]
        public IActionResult Add(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;  
            List<TextValueViewModel> Values = RecipeRepo.GetCategoryID();
            ViewBag.Recipe = Values;
            return View();
        }
        [Authorize(Roles = "Admin,Vendor")]
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
    }
}
