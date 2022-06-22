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
        public IActionResult Index(int id = 0,
                string name = "", string phone = "",
                string orderyBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            pubRepo.Get(id, name, phone, orderyBy,
                isAscending, pageIndex, pageSize);
            return View(data);
        }
        public ViewResult GetById(int id)
        {
            var data =
           pubRepo.Get(id);
            return View(data);
        }
    }
}
