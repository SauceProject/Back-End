using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RatingController : Controller
    {
        RatingRepository pubRepo;

        public RatingController()
        {
            DBContext dBContext = new DBContext();

            this.pubRepo = new RatingRepository(dBContext);
        }
        public IActionResult Get(int id = 0, int RatingValue = 0,
                string orderyBy = "", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            pubRepo.Get(id, RatingValue,orderyBy,
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
