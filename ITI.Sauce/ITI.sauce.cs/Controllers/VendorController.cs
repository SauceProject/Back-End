using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorRepository pubRepo;
        private readonly UnitOfWork UnitOfWork;


        public VendorController(VendorRepository _vendorRepo, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            this.pubRepo = _vendorRepo;
            UnitOfWork = _unitOfWork;
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Get(string id = "",
                string nameEN = "", string nameAR="", string Email = "",string phone = "",
                string orderyBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            pubRepo.Get(id, nameEN, nameAR, Email, phone, orderyBy,
                isAscending, pageIndex, pageSize);
            return View(data);
        }
        public IActionResult GetById(string id)
        {
            var data =
           pubRepo.Get(id);
            return View(data);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = pubRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
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


        [HttpGet]
        public IActionResult Update(string Id)
        {
            var Results = pubRepo.GetOne(Id);
            return View(Results.ToEditViewModel());
        }



        [HttpPost]
        public IActionResult Update(VendorEditViewModel model, int ID = 0)
        {

            pubRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");

        }

        [HttpGet]
        public IActionResult Remove(VendorEditViewModel model, int ID)
        {
            var res = pubRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");


        }

    }
}
