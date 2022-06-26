using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repositorie;
using ITI.Sauce.Models;
using ITI.Sauce.Repository;

namespace ITI.sauce.MVC.Controllers
{
    public class MemberShipController : Controller
    {
        MemberShipRepository MemberShipeRepo;
        public MemberShipController()
        { 
     this.MemberShipeRepo = new MemberShipRepository();
        }
public ViewResult Get(int id = 0, float Price = 0, string TypeEn = "", string TypeAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                         int pageSize = 20)
        {
            var ResultData =
               MemberShipeRepo.Get(id, Price, TypeEn, TypeAr, orderby, isAscending, pageIndex, pageSize);
            return View(ResultData);
        }

    }
}
