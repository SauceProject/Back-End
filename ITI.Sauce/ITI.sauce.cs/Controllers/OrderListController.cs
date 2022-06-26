﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ITI.Sauce.Models;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repositorie;

namespace ITI.sauce.MVC.Controllers
{
    public class OrderListController : Controller
    {
        OrderListRepository ordRepo;

        public OrderListController()
        {
            DBContext dBContext = new DBContext();

            this.ordRepo = new OrderListRepository(dBContext);
        }
        public ViewResult Get(int ID = 0, string orderBy = null
            , int OrderListQty = 0, bool isAscending = false
            , int pageIndex = 1, int pageSize = 20)

        {
            var data =
                ordRepo.Get(ID, orderBy, OrderListQty, isAscending, pageIndex, pageSize);
            return View(data);
        }
    }
}
