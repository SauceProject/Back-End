using ITI.Sauce.Models;
using ITI.Sauce.Repositories;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repositorie;


namespace ITI.sauce.MVC.Controllers
{
    public class IngredientController : Controller
    {
        IngredientRepository ingrRepo;

        public IngredientController()
        {
            DBContext dBContext = new DBContext();

            this.ingrRepo = new IngredientRepository(dBContext);
        }
        public ViewResult Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", string ImageUrl = "" , int pageIndex = 1, int pageSize = 20)
        {
            var data =
                ingrRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, ImageUrl, pageIndex, pageSize);
            
            return View (data);
        }

    }
}
