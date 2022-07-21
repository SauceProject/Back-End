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
        private readonly UnitOfWork UnitOfWork;

        public OrderController(OrderRepository _ordRepo, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            ordRepo = _ordRepo;
            UnitOfWork = _unitOfWork;
        }
        public IActionResult Get(int ID = 0, string orderBy = null, bool isAscending = false, string UserId = "",
             DateTime? registerDate = null,int pageIndex = 1, int pageSize = 20)
                    
        {
            var data =
                ordRepo.Get(ID, orderBy,isAscending, UserId, registerDate, pageIndex, pageSize);
            return View(data);
        }

        public IActionResult GetById(int id)
        {
            var data =
           ordRepo.Get(id);
            return View(data);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = ordRepo.Search(pageIndex, pageSize);
            return View("Get", Data);
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(OrderEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                ordRepo.Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Search");
            }
            else
                return View();
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            var Results = ordRepo.GetOne(Id);
            return View(Results.ToEditViewModel());
        }



        [HttpPost]
        public IActionResult Update(OrderEditViewModel model, int ID = 0)
        {

            ordRepo.Update(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");

        }

        [HttpGet]
        public IActionResult Remove(OrderEditViewModel model, int ID)
        {
            var res = ordRepo.Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Search");


        }
    }
}
