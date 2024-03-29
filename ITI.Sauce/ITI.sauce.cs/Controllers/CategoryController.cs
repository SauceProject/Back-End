﻿using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Authorization;

namespace ITI.sauce.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository CateRepo;
        private readonly UnitOfWork UnitOfWork;
        public CategoryController(CategoryRepository _cateRepo, UnitOfWork _unitOfWork)
        {
            CateRepo = _cateRepo;
            UnitOfWork = _unitOfWork;
        }

        //[Authorize(Roles = "User,Vendor")]

        public IActionResult Get (int ID =0 ,string orderBy = null, bool isAscending = false , string NameEN = "",
            string NameAR = "",int pageIndex = 1 , int pageSize = 20 )
        {
            var data =
                CateRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, pageIndex, pageSize);
            return View(data);
        }
        public IActionResult Search(int pageIndex = 1, int pageSize = 4)
        {
            var Data = CateRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }
        [HttpGet]
        public IActionResult Add ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add (CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                CateRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Get");
            }
            else
            {
                return View();
            }
           
        }





        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Results = CateRepo.GetOne(Id);

            return View(Results.ToEditViewModel());

        }






        [HttpPost]
        public IActionResult Update(CategoryEditViewModel model, int ID = 0)
        {
            CateRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");

        }






        [HttpGet]
        public IActionResult Remove(CategoryEditViewModel model, int ID)
        {
            var res = CateRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Get");


        }
    }
    
}
