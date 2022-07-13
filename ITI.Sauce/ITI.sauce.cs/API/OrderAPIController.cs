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
using ITI.Sauce.ViewModels.Shared;

namespace ITI.sauce.MVC.Controllers
{
    public class OrderAPIController : ControllerBase
    {
        OrderRepository ordRepo;
        private readonly UnitOfWork UnitOfWork;

        public OrderAPIController(OrderRepository _ordRepo, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            ordRepo = _ordRepo;
            UnitOfWork = _unitOfWork;
        }
        public ResultViewModel Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", DateTime? registerDate = null, int pageIndex = 1, int pageSize = 20)

        {
            var data =
                ordRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, registerDate, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

        public ResultViewModel GetById(int id)
        {
            var data =
           ordRepo.Get(id);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

     

        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public ResultViewModel Add()
        {
            List<TextValueViewModel> Values =  ordRepo.GetRecipeID();
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Values
            };
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ResultViewModel Add([FromBody] OrderEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                ordRepo.Add(model);
                UnitOfWork.Save();
                return new ResultViewModel()
                {
                    Message = "Added Succesfully",
                    Success = true,
                    Data = null
                };
            }
            else
                return new ResultViewModel()
                {
                    Message = "Added Succesfully",
                    Success = true,
                    Data = null
                };
        }


     


      

        [HttpGet]
        public ResultViewModel Remove(OrderEditViewModel model, int ID)
        {
            var res = ordRepo.Remove(model);
            UnitOfWork.Save();
            return new ResultViewModel()
            {
                Message = "Added Succesfully",
                Success = true,
                Data = null
            };

        }
    }
}
