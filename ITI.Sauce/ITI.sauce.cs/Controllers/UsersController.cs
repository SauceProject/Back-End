
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ITI.Sauce.Repository;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ITI.sauce.MVC.Controllers
{

    public class UsersController : Controller
    {
      
        private readonly UserRepository UserRepo;
        private readonly UnitOfWork UnitOfWork;
        private readonly RoleRepository RoleRepository;


        public UsersController(UserRepository _UserRepo, UnitOfWork _unitOfWork , RoleRepository _RoleRepository)
        {
            
            this.UserRepo = _UserRepo;
            DBContext dBContext = new DBContext();
            UnitOfWork = _unitOfWork;
            RoleRepository = _RoleRepository;
        }

        [Authorize(Roles = "Admin,User,Vendor")]
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
            ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
                .Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
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
                    ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
    .Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
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
        public async Task<IActionResult> SignIn(UserLoginViewModel model )
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


        [Authorize(Roles = "Admin")]
        public IActionResult GetById(string id)
        {
            var data =
             UserRepo.Get(id);
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = UserRepo.Search(pageIndex, pageSize);
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
            UserRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }
    }

}
