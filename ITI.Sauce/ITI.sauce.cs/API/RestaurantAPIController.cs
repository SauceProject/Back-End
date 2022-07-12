using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ITI.sauce.MVC.Controllers
{
    public class RestaurantAPIController : ControllerBase
    {

        private readonly RestaurantRepository ResRepo;
        private readonly UnitOfWork UnitOfWork;
        public RestaurantAPIController(RestaurantRepository _RepoRes, UnitOfWork _unitOfWork)
        {
            //DBContext dBContext = new DBContext();
            this.ResRepo = _RepoRes;
            UnitOfWork = _unitOfWork;
        }
        //[Authorize(Roles = "Admin,User,Vendor")]
        public ResultViewModel Get(string vendorID = "", int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var Resultdata =
                ResRepo.Get(vendorID, id, WorkTime, NameEn, NameAr, registerDate, isDeleted, orderby, isAscending, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Resultdata
            };
        }
    
    












       
    }
}
