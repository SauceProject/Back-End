
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ITI.Sauce.Repository;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;

namespace ITI.sauce.MVC.Controllers
{

    public class UsersController : Controller
    {
      
        private readonly UserRepository UserRepo;
        private readonly UnitOfWork UnitOfWork;


        public UsersController(UserRepository _UserRepo, UnitOfWork _unitOfWork)
        {
            
            this.UserRepo = _UserRepo;
            DBContext dBContext = new DBContext();
            UnitOfWork = _unitOfWork;
        }
       
        public IActionResult Get(string id = "", string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {
            var Resultdata =
            UserRepo.Get(id, UserName, Email, phone, registerDate, NameEn, NameAr, orderby, isAscending, pageIndex, pageSize);

            return View(Resultdata);

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result
                        = await UserRepo.SignUp(model);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                else
                {
                    return RedirectToAction("SignIn", "Users");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result
                        = await UserRepo.SignIn(model);
                if (!result.Succeeded)
                {
                        ModelState.AddModelError("", "Invalid UserName Or Password");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await UserRepo.SignOut();
            return RedirectToAction("SignIn","Users");
        }


    
        public IActionResult GetById(string id)
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
        public IActionResult Add(UserEditViewModel model)
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
