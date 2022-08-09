
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ITI.Sauce.Repository;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace ITI.sauce.MVC.Controllers
{

    public class UsersController : Controller
    {

        private readonly UserRepository UserRepo;
        private readonly VendorRepository VendorRepo;

        private readonly UnitOfWork UnitOfWork;
        private readonly RoleRepository RoleRepository;



        public UsersController(UserRepository _UserRepo, UnitOfWork _unitOfWork, RoleRepository _RoleRepository, VendorRepository _VendorRepo)
        {

            this.UserRepo = _UserRepo;
            this.VendorRepo = _VendorRepo;
            //DBContext dBContext = new DBContext();
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
            return View(new UserEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result
                        = await UserRepo.SignUp(model);
        //            if (!result.IsSuccess)
        //            {
        //                ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
        //.Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
        //                foreach (var error in result.Errors)
        //                    ModelState.AddModelError("", error.Description);
        //            }
        //            else
        //            {
                        if (model.Role == "Vendor")
                        {
                            VendorRepo.Add(new VendorEditViewModel { Id = result.UserId, registerDate = DateTime.Now });
                            UnitOfWork.Save();
                        }
                    }
                    return RedirectToAction("SignIn", "Users");
            //}
            //else
            //{
            //    ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
            //    .Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
            //    return View(model);
            //}

        }

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SignIn(UserLoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result
        //                = await UserRepo.SignIn(model);
        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", "Invalid UserName Or Password");
        //        }
        //        else
        //        {


        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //    return View();
        //}

        ////api
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string token
                        = await UserRepo.SignIn(model);
                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password");
                    return View();
                }
                else
                {


                    //    return new ObjectResult(new
                    //    {

                    //        Token = token,
                    //    });
                    return RedirectToAction("Index", "Home");
                }
                
            }
            List<string> errors = new List<string>();
            foreach (var i in ModelState.Values)
                foreach (var error in i.Errors)
                    errors.Add(error.ErrorMessage);
            return View();
        }
        public IActionResult Details(string id)
        {
            var data = UserRepo.Get(id);
            foreach (var i in data.Data)
            {
                ViewBag.NameEN = i.NameEN;
                ViewBag.NameAR = i.NameAR;
                ViewBag.Email = i.Email;
                ViewBag.Phone = i.phone;
                //ViewBag.Password = i.Password;
                //ViewBag.UserName = i.UserName;
            }
            return View(data);
        }

        [HttpGet]
        public new async Task<IActionResult> SignOut()
        {
            await UserRepo.SignOut();
            return RedirectToAction("SignIn", "Users");
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
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
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

        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.IsSuccess = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswardViewModel model)
        {
            model.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await UserRepo.ChangePassward(model);
            {
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = true;
                }

            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string uid, string token)
        {
            token = token.Replace(' ', '+');
            var result = await UserRepo.ConfirmEmail(uid, token);
            if (result.Succeeded)
                ViewBag.Success = true;
            else
                ViewBag.Success = false;
            
            return View();
        }
    }
}
