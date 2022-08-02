using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;

namespace ITI.sauce.MVC.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorRepository vendorRepo;
        private readonly UserRepository userRepo;
        private readonly UnitOfWork UnitOfWork;
        private readonly RestaurantRepository restaurantRepository;
        private readonly Vendor_MembershipRepository vendorMemberRepo;
        private readonly MemberShipRepository memberShipRepository;
        private readonly RecipeRepository recipeRepository;
        private readonly OrderListRepository orderListRepository;





        public VendorController(VendorRepository _vendorRepo, UnitOfWork _unitOfWork,
            UserRepository _userRepo, Vendor_MembershipRepository _vendorMemberRepo,
            MemberShipRepository _memberShipRepository, RestaurantRepository _restaurantRepository,
            RecipeRepository recipeRepository, OrderListRepository _orderListRepository)
        {
            //DBContext dBContext = new DBContext();
            this.vendorRepo = _vendorRepo;
            this.userRepo = _userRepo;
            UnitOfWork = _unitOfWork;
            vendorMemberRepo = _vendorMemberRepo;
            memberShipRepository = _memberShipRepository;
            restaurantRepository = _restaurantRepository;
            this.recipeRepository = recipeRepository;
            orderListRepository = _orderListRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Get(string id = "",
                string nameEN = "", string nameAR = "", string Email = "", string phone = "",
                string orderyBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 5)
        {
            var data =
            vendorRepo.Get(id, nameEN, nameAR, Email, phone, orderyBy,
                isAscending, pageIndex, pageSize);
            return View(data);

        }



        public IActionResult Details(string id)
        {
            var data = vendorRepo.Get(id);
            foreach (var i in data.Data)
            {
                ViewBag.NameEN = i.NameEN;
                ViewBag.NameAR = i.NameAR;
                ViewBag.Email = i.Email;
                //ViewBag.Phone = i.phone;
                //ViewBag.Password = i.Password;
                //ViewBag.UserName = i.UserName;
            }
            return View(data);
        }

        [Authorize(Roles = "Admin")]


        public IActionResult Search(int pageIndex = 1, int pageSize = 4)
        {
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var Data = vendorRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new UserEditViewModel { Role = "Vendor" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(UserEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                var result = await userRepo.SignUp(model);
                if (!string.IsNullOrEmpty(result.UserId))
                {
                    vendorRepo.Add(new VendorEditViewModel { Id = result.UserId, registerDate = DateTime.Now });
                    UnitOfWork.Save();
                    return RedirectToAction("Search");
                }
                else
                {
                    return View();
                }

            }
            else
                return View();
        }


        [HttpGet]
        public IActionResult Update(string Id)
        {
            var Results = vendorRepo.GetOne(Id);
            return View(Results.ToEditViewModel());
        }


        [HttpPost]
        public IActionResult Update(VendorEditViewModel model, int ID = 0)
        {

            vendorRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");

        }

        [HttpGet]
        public IActionResult Remove(string ID)
        {

            var res = vendorRepo.Remove(ID);
            UnitOfWork.Save();
            return RedirectToAction("Search");


        }
        public IActionResult AddMemberShip(string Id, int membershipid)
        {

            vendorMemberRepo.Add(Id, membershipid);
            UnitOfWork.Save();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetMemberships(string VendorID)
        {
            ViewBag.Bronze = memberShipRepository.GetList().FirstOrDefault(i => i.TypeEn == "Bronze");
            ViewBag.Silver = memberShipRepository.GetList().FirstOrDefault(i => i.TypeEn == "Silver");
            ViewBag.Golden = memberShipRepository.GetList().FirstOrDefault(i => i.TypeEn == "Golden");
            ViewBag.Free = memberShipRepository.GetList().FirstOrDefault(i => i.TypeEn == "Free");
            var m = vendorRepo.GetOne(VendorID);
            ViewBag.vendorMemberships = m.MemberShips;


            return View();
        }


        public IActionResult AcceptVendor(string ID)
        {
            vendorRepo.AcceptVendor(ID);
            UnitOfWork.Save();
            return RedirectToAction("Search");
        }
        public IActionResult GetOrders(string vendorID, int pageIndex=1,int pageSize=20)
        {
            //var rest = restaurantRepository.GetAPI(Vendor_ID);
            //var recipeIDS = GetVendorRecipes(rest.Data);
            //List<OrderListViewModel> orders = new List<OrderListViewModel>();
            //var list = orderListRepository.Get().Data;
            //foreach ( var o in list )
            //{
            //    foreach(var rID in recipeIDS)
            //    {
            //        if (o.RecipeID == rID)
            //            orders.Add(o);
            //    }
            //}
            var res = vendorRepo.GetOrders(vendorID, pageIndex, pageSize);
            return View("GetOrders",res);
        }
        //private List<int> GetVendorRecipes(List<RestaurantViewModel> VendorRestaurants)
        //{
        //    List<int> recipeIDS = new List<int>();
        //    foreach (var r in VendorRestaurants)
        //    {
        //        foreach (var rec in recipeRepository.GetList())
        //        {
        //            if (rec.ResturantID == r.ID)
        //                recipeIDS.Add(rec.ID);
        //        }           
        //    }
        //    return recipeIDS;
        //}
    }
}
