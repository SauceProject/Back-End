
using ITI.Sauce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class VendorController : Controller
    {
        VendorRepository pubRepo;

        public VendorController()
        {
            this.pubRepo = new VendorRepository();
        }
        public IActionResult Get(int id = 0,
                string nameEN = "", string nameAR="", string Email = "",string phone = "",
                string orderyBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            pubRepo.Get(id, nameEN, nameAR, Email, phone, orderyBy,
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
