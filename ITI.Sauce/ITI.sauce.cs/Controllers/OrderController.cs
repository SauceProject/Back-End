using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ITI.Sauce.Models;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;

namespace ITI.sauce.MVC.Controllers
{
    public class OrderController : Controller
    {
        OrderRepository ordRepo;

        public OrderController(OrderRepository _ordRepo)
        {
            ordRepo = _ordRepo;
        }
        public ViewResult Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", DateTime? registerDate = null,int pageIndex = 1, int pageSize = 20)
                    
        {
            var data =
                ordRepo.Get(ID, orderBy,isAscending, NameEN, NameAR, registerDate, pageIndex, pageSize);
            return View(data);
        }


    }
}
