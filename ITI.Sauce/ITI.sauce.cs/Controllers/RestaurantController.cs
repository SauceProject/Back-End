using ITI.Sauce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantController : Controller
    {
        RestaurantRepository pubRepo;

        public RestaurantController()
        {
            this.pubRepo = new RestaurantRepository();
        }
        public IActionResult Get(int id = 0,
            string nameEN = "", string nameAR = "",
                string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {
            var data =
            pubRepo.Get(id, nameEN, nameAR, orderby,
                isAscending, pageIndex, pageSize);
            return View(data);
        }
        public IActionResult GetById(int id)
        {
            var data =
           pubRepo.Get(id);
            return View(data);
        }
    }
}
