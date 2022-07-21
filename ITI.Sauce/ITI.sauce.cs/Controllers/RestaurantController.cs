using System.Security.Claims;
using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantRepository ResRepo;
        private readonly UnitOfWork UnitOfWork;
        public RestaurantController(RestaurantRepository _RepoRes, UnitOfWork _unitOfWork)
        {
            this.ResRepo = _RepoRes;
            UnitOfWork = _unitOfWork;
        }
        //[Authorize(Roles = "Admin,User,Vendor")]
        public IActionResult Get(string vendorID = "", int id = 0, DateTime? WorkTime = null,
            string NameEn = "", string NameAr = "", DateTime? registerDate = null,
            bool isDeleted = false, string orderby = "ID", bool isAscending = false,
            int pageIndex = 1, int pageSize = 20)
        {
            var Resultdata =
                ResRepo.Get(vendorID, id, WorkTime, NameEn, NameAr, registerDate, isDeleted, orderby, isAscending, pageIndex, pageSize);
            return View("Get", Resultdata);
        }
        //[Authorize(Roles = "Admin,Vendor")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 4)
        {
           
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Reataurant = ResRepo.GetList().Where(v => v.Vendor_ID == userId);
            var Data = ResRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [Authorize(Roles = "Vendor")]
        [HttpGet]
        public IActionResult Add()
        {
            var claimsIdentity = (System.Security.Claims.ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            return View(new RestaurantEditViewModel { Vendor_ID = userId });
        }
        private IEnumerable<SelectListItem> GetRestaurantNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
        }

        [Authorize(Roles = "Vendor")]
        [HttpPost]
        public IActionResult Add(RestaurantEditViewModel model)
        {
            //model.
            string? bookUploadUrl = "/Content/Uploads/Resturant/";

            string newFileName = Guid.NewGuid().ToString() + model.Image.FileName;
            model.ImageUrl = bookUploadUrl + newFileName;

            FileStream fs = new FileStream(Path.Combine
                (
                    Directory.GetCurrentDirectory(),
                    "Content",
                   "Uploads", "Resturant", newFileName
                ), FileMode.Create);

            model.Image.CopyTo(fs);
            fs.Position = 0;

            ResRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");
        }





        [HttpGet]
        public IActionResult Update(int Id)
        {
            IEnumerable<SelectListItem> Restaurants =
                GetRestaurantNames(ResRepo.GetCRestaurantDropDown());
            ViewBag.Restaurants = Restaurants;
            var Results = ResRepo.GetOne(Id);

            return View(Results.ToEditViewModel());

        }






        [HttpPost]
        public IActionResult Update(RestaurantEditViewModel model, int ID = 0)
        {
            ResRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }




        [HttpGet]
        public IActionResult Remove(RestaurantEditViewModel model, int ID)
        {

            var res = ResRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");


        }
        public  IActionResult  AcceptRestaurant(RestaurantEditViewModel model, int ID)
        {
            ResRepo.AcceptRestaurant(model, ID);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }
    }
}
