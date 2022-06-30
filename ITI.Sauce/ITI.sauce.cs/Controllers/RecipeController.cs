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
        public RecipeController(RecipeRepository _RecipeRepo, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.RecipeRepo = _RecipeRepo;
            UnitOfWork = _unitOfWork;
        }
        public ViewResult Get(string NameAr = null, string NameEN = null,
            string orderBy = null,
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20)
        {
            var data = RecipeRepo.Get(
                NameAr, NameEN, orderBy, 
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
            if (ModelState.IsValid == true)
            {
                RecipeRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }
}
