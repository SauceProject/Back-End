using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Models;
using ITI.Sauce.Repository;

namespace ITI.sauce.MVC.Controllers
{
    public class MemberShipController : Controller
    {
        MemberShipRepository MemberShipeRepo;
        public MemberShipController()
        {
            DBContext dBContext = new DBContext();

            this.MemberShipeRepo = new MemberShipRepository(dBContext);
        }
        public ViewResult Get(int id = 0, string Type = "", float Price = 0, string TypeEn = "", string TypeAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,

                         int pageSize = 20)
        {
            var ResultData =
               MemberShipeRepo.Get(id, Type, Price, TypeEn, TypeAr, orderby, isAscending, pageIndex, pageSize);
            return View(ResultData);
        }

        public ViewResult GetVendorMemperShip(int VendorId = 0)
        {
            return View();
        }

    }
}
