﻿using ITI.Sauce.Models;
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
    public class CategoryController : Controller
    {
        CategoryRepository cateRepo;

        public CategoryController()
        {
            DBContext dBContext = new DBContext();

            this.cateRepo = new CategoryRepository(dBContext);
        }

        public ViewResult Get (int ID =0 ,string orderBy = null, bool isAscending = false , string NameEN = "",
            string NameAR = "",int pageIndex = 1 , int pageSize = 20 )
        {
            var data =
                cateRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, pageIndex, pageSize);
            return View(data);
        }
    }
    
}
