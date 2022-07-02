using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
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
            this.RecipeRepo = _RecipeRepo;
            UnitOfWork = _unitOfWork;
            VendorRepo = _VendorRepo;
        }
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
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = RecipeRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<TextValueViewModel> Values = RecipeRepo.GetCategoryID();
            ViewBag.Recipe = Values;
            return View();
        }
        [HttpPost]
        public IActionResult Add(RecipeEditViewModel model)
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
            var recipe = RecipeRepo.GetOne(ID);
            ViewBag.CurrentRecipe = recipe;
            return View();
        }
        [HttpPost]
        public IActionResult Update(RecipeEditViewModel model, int ID)
        {
            
            RecipeRepo.Update(model, ID);
            UnitOfWork.Save();
            return RedirectToAction("Get");
           
        }

    }
}
