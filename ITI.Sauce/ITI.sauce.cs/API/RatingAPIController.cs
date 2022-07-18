using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ITI.sauce.MVC.Controllers
{
    public class RatingAPIController : ControllerBase
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly RatingRepository RatepRepo;


        public RatingAPIController(UnitOfWork _unitOfWork
            , RatingRepository _RatepRepo)
        {
            UnitOfWork = _unitOfWork;
            RatepRepo = _RatepRepo;
        }
        public ResultViewModel Get(int id = 0, int RatingValue = 0,
                string orderyBy = "", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            var data =
            RatepRepo.Get(id, RatingValue,null, orderyBy,
                isAscending, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message="",
                Data=data
            };
        }
        public IActionResult GetById(int id)
        {
            var data =
           RatepRepo.Get(id);
            return new ObjectResult(data);
        }
        
        [HttpGet]
        public ResultViewModel Add()
        {
            List<TextValueViewModel> Values = RatepRepo.GetRecipeID();
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Values
            };
        }
        [HttpPost]
        public ResultViewModel Add(RatingEditViewModel model)
        {
            if (ModelState.IsValid == true)
            {
                RatepRepo.Add(model);
                UnitOfWork.Save();
                return new ResultViewModel()
                {
                    Message = "Added Succesfully",
                    Success=true,
                    Data=null
                }; 
            }
            else { 
                List<string> errors = new List<string>();
            foreach (var i in ModelState.Values)
                foreach (var error in i.Errors)
                    errors.Add(error.ErrorMessage);
                return new ResultViewModel()
                {
                    Message = "Not Added ",
                    Success = false,
                    Data = null
                };
            }
        }

        [HttpGet]
        public ResultViewModel Update(int Id)
        { 
                var Results = RatepRepo.GetOne(Id);
            return new ResultViewModel()
            {
                Message = "",
                Success = true,
                Data = Results
            };
        }


        [HttpPost]
        public ResultViewModel Update(RatingEditViewModel model, int ID = 0)
        {
            if (ModelState.IsValid == true)
            { 
                RatepRepo.Update(model);
            UnitOfWork.Save();
            return new ResultViewModel()
            {
                Message = "Update Succesfully",
                Success = true,
                Data = null
            };
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var i in ModelState.Values)
                    foreach (var error in i.Errors)
                        errors.Add(error.ErrorMessage);
                return new ResultViewModel()
                {
                    Message = "Not Updated ",
                    Success = false,
                    Data = null
                };
            }

        }

        [HttpGet]
        public ResultViewModel Remove(RatingEditViewModel model, int ID)
        {
            if (ModelState.IsValid == true) { 
                var res = RatepRepo.Remove(model);
            UnitOfWork.Save();
            return new ResultViewModel()
            {
                Message = "Remove Succesfully",
                Success = true,
                Data = null
            };
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var i in ModelState.Values)
                    foreach (var error in i.Errors)
                        errors.Add(error.ErrorMessage);
                return new ResultViewModel()
                {
                    Message = "Not Removed ",
                    Success = false,
                    Data = null
                };
            }


        }

       
        

    }
}
