using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorRepository pubRepo;
        private readonly UnitOfWork UnitOfWork;


        public VendorController(VendorRepository _vendorRepo, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.pubRepo = _vendorRepo;
            UnitOfWork = _unitOfWork;
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
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = pubRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(VendorEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                pubRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }
}
