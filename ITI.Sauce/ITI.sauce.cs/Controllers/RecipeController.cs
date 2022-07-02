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
        public RecipeController(RecipeRepository _RecipeRepo, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.RecipeRepo = _RecipeRepo;
            UnitOfWork = _unitOfWork;
        }
        [Authorize(Roles = "Admin,User,Vendor")]
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
            if (ModelState.IsValid == true)
            {
                RecipeRepo.Add(model);
                UnitOfWork.Save();
                if(!string.IsNullOrEmpty(returnUrl))
                    return LocalRedirect(returnUrl);
                else
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }
}
