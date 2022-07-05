using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.ViewModels;


namespace ITI.sauce.MVC.Controllers
{
    public class MemberShipController : Controller
    {
        private readonly MemberShipRepository MemberShipeRepo;
        private readonly UnitOfWork UnitOfWork;
        public MemberShipController(MemberShipRepository _RepoMemberShip, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            this.MemberShipeRepo = _RepoMemberShip;
            UnitOfWork = _unitOfWork;
        }
        public IActionResult Get(int id = 0, float Price = 0, string TypeEn = "", string TypeAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,

                         int pageSize = 20)
        {
            var ResultData =
               MemberShipeRepo.Get(id, Price, TypeEn, TypeAr, orderby, isAscending, pageIndex, pageSize);
            return View(ResultData);
        }

        public IActionResult GetVendorMemperShip(int VendorId = 0)
        {
            return View();
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = MemberShipeRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MemberShipEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                MemberShipeRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }





        [HttpGet]
        public IActionResult Update(int ID)
        {
            var Results = MemberShipeRepo.GetOne(ID);

            return View(Results.ToEditViewModel());

        }






        [HttpPost]
        public IActionResult Update(MemberShipEditViewModel model, int ID = 0)
        {
            MemberShipeRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }
    }

}

