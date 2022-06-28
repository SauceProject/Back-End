using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc;



namespace ITI.sauce.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository UserRepo;
        private readonly UnitOfWork UnitOfWork;


        public UsersController(UserRepository _RepoUser, UnitOfWork _unitOfWork)
        {
            DBContext dBContext = new DBContext();
            this.UserRepo = _RepoUser;
            UnitOfWork = _unitOfWork;
        }
        public IActionResult Get(int id = 0, string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {
            var Resultdata =
            UserRepo.Get(id, UserName, Email, phone, registerDate, NameEn, NameAr, orderby, isAscending, pageIndex, pageSize);

            return View(Resultdata);

        }

        public IActionResult GetById(int id)
        {
            var data =
           UserRepo.Get(id);
            return View(data);
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = UserRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(UsersEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                UserRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }

}
