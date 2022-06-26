using ITI.Sauce.Repositories;
using Microsoft.AspNetCore.Mvc;

using ITI.Sauce.Repositorie;
using ITI.Sauce.Repository;
using ITI.Sauce.Models;

namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantController : Controller
    {
       
        RestaurantRepository ResRepo;
        public RestaurantController()
        {
            DBContext dBContext = new DBContext();

            this.ResRepo = new RestaurantRepository(dBContext);
        }
        public ViewResult Get(int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var Resultdata =
                ResRepo .Get (id, WorkTime, NameEn, NameAr, registerDate, isDeleted, orderby, isAscending, pageIndex, pageSize);
            return View(Resultdata);
        }

    }
}
