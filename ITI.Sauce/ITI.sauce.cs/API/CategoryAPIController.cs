using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ITI.Sauce.Repository;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ITI.Sauce.ViewModels.Shared;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;


namespace ITI.Sauce.MVC.Controllers
{
    public class CategoryAPIController : ControllerBase
    {
        private readonly CategoryRepository CateRepo;
        private readonly UnitOfWork UnitOfWork;
        public CategoryAPIController(CategoryRepository _cateRepo, UnitOfWork _unitOfWork)
        {
            CateRepo = _cateRepo;
            UnitOfWork = _unitOfWork;
        }

        //[Authorize(Roles = "User")]

        public ResultViewModel Get(int ID = 0, string orderBy = null, bool isAscending = false, string NameEN = "",
          string NameAR = "", int pageIndex = 1, int pageSize = 20)
        {
            var data =
                CateRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, pageIndex, pageSize);
           
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };


        }

        [HttpGet]
        public ResultViewModel Details(int Id)
        {
            var result = CateRepo.Get(Id);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = result
            };
        }
    }
}





        //var data =
        //    CateRepo.Get(ID, orderBy, isAscending, NameEN, NameAR, pageIndex, pageSize);
        //return null;
  

