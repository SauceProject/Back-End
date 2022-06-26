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
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repositorie;
using ITI.Sauce.Repository;



namespace ITI.sauce.MVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IngredientRepository IngrRepo;
        private readonly UnitOfWork UnitOfWork;

<<<<<<< HEAD
        public IngredientController(IngredientRepository _ingrRepo, UnitOfWork _unitOfWork)
        {
            IngrRepo = _ingrRepo;
            UnitOfWork = _unitOfWork;
=======
        public IngredientController()
        {
            DBContext dBContext = new DBContext();

            this.ingrRepo = new IngredientRepository(dBContext);
>>>>>>> 783921fa5e0bed8b700af798c7f20caf4a815bea
        }


        public ViewResult Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", string ImageUrl = "" , int pageIndex = 1, int pageSize = 20)
        {
            var data =
                IngrRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, ImageUrl, pageIndex, pageSize);
            
            return View (data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IngredientEditViewModel model)
        {
            IngrRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");
        }

    }
}
