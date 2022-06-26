using ITI.Sauce.Models;
using ITI.Sauce.Repositorie;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeRepository RecipeRepo;
        public RecipeController()
        {
            DBContext dBContext = new DBContext();

            RecipeRepo = new RecipeRepository(dBContext);
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
    }
}
