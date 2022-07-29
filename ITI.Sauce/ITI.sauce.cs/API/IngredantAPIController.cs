using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels.Shared;

namespace ITI.sauce.MVC.Controllers
{
    public class IngredientAPIController : ControllerBase
    {
        private readonly IngredientRepository IngrRepo;
        private readonly UnitOfWork UnitOfWork;

        public IngredientAPIController(IngredientRepository _ingrRepo, UnitOfWork _unitOfWork)
        {
            IngrRepo = _ingrRepo;
            UnitOfWork = _unitOfWork;
        }

        public ResultViewModel Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
            string NameAR = "", string ImageUrl = "", int pageIndex = 1, int pageSize = 20)
        {
            var data =
                IngrRepo.GetAPI(ID, orderBy, isAscending, NameEN, NameAR, ImageUrl, pageIndex, pageSize);

            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

        public IActionResult GetById(int id)
        {
            var data =
           IngrRepo.Get(id);
            return new ObjectResult(data);
        }

        public ResultViewModel Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = IngrRepo.Search(pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Data
            };
        }

    }
}


