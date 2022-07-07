using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorRepository vendorRepo;
        private readonly UserRepository userRepo;
        private readonly UnitOfWork UnitOfWork;


        public VendorController(VendorRepository _vendorRepo, UnitOfWork _unitOfWork,
            UserRepository _userRepo)
        {
            //DBContext dBContext = new DBContext();
            this.vendorRepo = _vendorRepo;
            this.userRepo = _userRepo;
            UnitOfWork = _unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Get(string id = "",
                string nameEN = "", string nameAR="", string Email = "",string phone = "",
                string orderyBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            vendorRepo.Get(id, nameEN, nameAR, Email, phone, orderyBy,
                isAscending, pageIndex, pageSize);
            return View(data);
        }
        public IActionResult Details(string id)
        {
            var data = vendorRepo.Get(id);
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = vendorRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        
   


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(UserEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                var VendorEditView= userRepo.Add(model).ToVendorEditViewModel();
                vendorRepo.Add(VendorEditView);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }


        [HttpGet]
        public IActionResult Update(string Id)
        {
            var Results = vendorRepo.GetOne(Id);
            return View(Results.ToEditViewModel());
        }


        [HttpPost]
        public IActionResult Update(VendorEditViewModel model, int ID = 0)
        {

            vendorRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");

        }

        [HttpGet]
        public IActionResult Remove(VendorEditViewModel model, int ID)
        {
            var res = vendorRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");


        }

    }
}
