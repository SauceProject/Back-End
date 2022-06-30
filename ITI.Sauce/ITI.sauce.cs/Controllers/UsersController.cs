
using Microsoft.AspNetCore.Mvc;

using ITI.Sauce.Repository;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ITI.sauce.MVC.Controllers
{
    
    public class UsersController : Controller
    {
        UserRepository UserRepo;
        

        public UsersController(UserRepository _UserRepo)
        {
            
            this.UserRepo = _UserRepo;
        }
        public ViewResult Get(string id = "", string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
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


    }
}
