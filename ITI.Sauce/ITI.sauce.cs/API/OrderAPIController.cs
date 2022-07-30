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
        CartRepository cartRepository;
        RecipeRepository recipeRepository;
        OrderListRepository orderListRepository;

        public OrderAPIController(OrderRepository _ordRepo, CartRepository _cartRepository,
             RecipeRepository _recipeRepository, OrderListRepository _orderListRepository, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            ordRepo = _ordRepo;
            UnitOfWork = _unitOfWork;
            cartRepository = _cartRepository;
            recipeRepository= _recipeRepository;
            orderListRepository = _orderListRepository;

        }
        [HttpGet]
        public ResultViewModel Get(int ID = 0, string orderBy = null, bool isAscending = false,
            string UserId = "", DateTime? registerDate = null, int pageIndex = 1, int pageSize = 20)

        {
            var data =
                ordRepo.GetAPI(ID, orderBy, isAscending, UserId, registerDate, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

        [HttpGet]
        public ResultViewModel GetLastOrder(int ID = 0, string orderBy = null, bool isAscending = false,
            string UserId = "", DateTime? registerDate = null, int pageIndex = 1, int pageSize = 20)

        {
            var data =
                ordRepo.GetAPI(ID, orderBy, isAscending, UserId, registerDate, pageIndex, pageSize);
            int OrderID = 0;
            foreach(var o in data.Data)
            {
                if(o.OrderDate.ToString("MM-dd-yyyy") == DateTime.Now.ToString("MM-dd-yyyy"))
                {
                    OrderID = o.ID;
                }
            }
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = OrderID
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
           // List<TextValueViewModel> Values =  ordRepo.GetRecipeID();
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = null
            };
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ResultViewModel Add([FromBody] OrderEditViewModel model)
        {
            var userCarts = cartRepository.GetByUser(model.UserId);
            int i = 0;
            foreach (var c in userCarts.Data)
            {
                var recipe = recipeRepository.GetOne(c.Recipe_ID);
                //model.orderLists[i].OrderID = model.ID;
                model.orderLists[i].OrderListPrice = recipe.Price;
                model.orderLists[i].OrderListQty = c.Qty;
                model.orderLists[i].Recipe_ID = recipe.ID;

                i++;
            }
            model.OrderDate = DateTime.Now;
            ordRepo.Add(model);


            //model.OrderDate = DateTime.Now;
            //var res= ordRepo.Add(model);
            //foreach (var c in userCarts.Data)
            //{
            //    var recipe = recipeRepository.GetOne(c.Recipe_ID);
            //    orderListRepository.Add(new OrderListEditViewModel
            //    {
            //        OrderID = res.ID,
            //        OrderListQty = c.Qty,
            //        RecipeID = c.Recipe_ID,
            //        OrderListPrice = recipe.Price,                    

            //    });
            //}



            foreach (var c in userCarts.Data)
            {
                cartRepository.Remove(c.ID);
            }

            UnitOfWork.Save();
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
