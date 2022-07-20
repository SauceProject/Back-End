
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

    public class UserAPIController : ControllerBase
    {

        private readonly UserRepository UserRepo;
        private readonly UnitOfWork UnitOfWork;
        private readonly RoleRepository RoleRepository;


        public UserAPIController(UserRepository _UserRepo, UnitOfWork _unitOfWork, RoleRepository _RoleRepository)
        {

            this.UserRepo = _UserRepo;
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

            return null;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            //ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
            //.Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result
                        = await UserRepo.SignUp(model);

                if (!result.IsSuccess)
                {
                    //ViewBag.Roles = RoleRepository.GetDropDownValue().Where(i => i.Text != "Admin")
                    //.Select(i => new SelectListItem(i.Text, i.Text.ToString())).ToList();
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                else
                {
                    if (model.Role == "Vendor")
                    {
                        //vendorRepo.Add(new VendorEditViewModel { Id=result,registerDate=DateTime.Now});
                    }
                    return new ObjectResult(new
                    {
                        Message = " LOgin Sucess",
                        SignInUrl = "userApI/SignIn",
                        Success = true
                    });
                }
            }
            return new ObjectResult(new
            {
                Message = " invalid input",
                SignInUrl = "userApI/SignIn",
                Success = false
            });
        }

        [HttpGet]
        public IActionResult SignIn(string? returnUrl)
        {

            return new ObjectResult(new
            {
                Message = "Plese LOgin",
                SignInUrl = "userApI/SignIn",
                Success = false

            });
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserLoginViewModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                string token
                        = await UserRepo.SignIn(model);
                if (string.IsNullOrEmpty(token))
                {
                    ModelState.AddModelError("", "Invalid UserName Or Password");
                }
                else
                {


                    return new ObjectResult(new
                    {

                        Token = token,
                        ReturnUrl = returnUrl,
                        Success = true
                    });
                }
            }


        
                List<string> errors = new List<string>();
            foreach (var i in ModelState.Values)
                foreach (var error in i.Errors)
                    errors.Add(error.ErrorMessage);
            return new ObjectResult(errors);
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
            return null;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = UserRepo.Search(pageIndex, pageSize);
            return null;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return null;
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
                return null;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {

            return null;
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

                }

            }
            return null;
        }
    }

}
