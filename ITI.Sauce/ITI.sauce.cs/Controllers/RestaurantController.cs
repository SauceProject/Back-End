using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantController : Controller
    {

        private readonly RestaurantRepository ResRepo;
        private readonly UnitOfWork UnitOfWork;
        public RestaurantController(RestaurantRepository _RepoRes, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.ResRepo = _RepoRes;
            UnitOfWork = _unitOfWork;
        }
        public IActionResult Get(int vendorID = 0,int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var Resultdata =
                ResRepo .Get (vendorID,id, WorkTime, NameEn, NameAr, registerDate, isDeleted, orderby, isAscending, pageIndex, pageSize);
            return View(Resultdata);
        }

        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = ResRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                ResRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }
}
