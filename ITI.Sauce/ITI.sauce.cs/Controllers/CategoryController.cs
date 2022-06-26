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
    public class CategoryController : Controller
    {
        private readonly CategoryRepository CateRepo;
        private readonly UnitOfWork UnitOfWork;
        public CategoryController (CategoryRepository _cateRepo, UnitOfWork _unitOfWork)
        {
            CateRepo = _cateRepo;
            UnitOfWork = _unitOfWork;
        }

        public ViewResult Get (int ID =0 ,string orderBy = null, bool isAscending = false , string NameEN = "",
            string NameAR = "",int pageIndex = 1 , int pageSize = 20 )
        {
            var data =
                CateRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, pageIndex, pageSize);
            return View(data);
        }

        [HttpGet]
        public IActionResult Add ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add (CategoryEditViewModel model)
        {
            CateRepo.Add(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");
        }
    }
    
}
