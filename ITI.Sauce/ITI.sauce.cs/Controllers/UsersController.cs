﻿
using Microsoft.AspNetCore.Mvc;

using ITI.Sauce.Repositorie;

namespace ITI.sauce.MVC.Controllers
{
    public class UsersController : Controller
    {
        UserRepository UserRepo;

        public UsersController()
        {
            this.UserRepo = new UserRepository();
        }
          public ViewResult Get(int id = 0, string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {
            var Resultdata = 
            UserRepo.Get(id,UserName,Email,phone,registerDate,NameEn,NameAr,orderby,isAscending,pageIndex,pageSize);

            return View(Resultdata);

        }

    }
}