using ITI.Sauce.Models;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ITI.Sauce.MVC
{
    public class FavAPIController : ControllerBase
    {
        private readonly FavRepository FavRepo;
        
        private readonly UnitOfWork UnitOfWork;


        public FavAPIController(FavRepository _FavRepo, UnitOfWork _unitOfWork)
        {
            this.FavRepo = _FavRepo;
            UnitOfWork = _unitOfWork;
        }

        
        public ResultViewModel Get(int Fav_ID = 0,
                string orderBy = "ID", bool isAscending = false,
                int pageIndex = 1, int pageSize = 20)
        {
            PaginingViewModel<List<FavoriteViewModel>> result
                = FavRepo.Get(Fav_ID, orderBy, isAscending,
                 pageIndex, pageSize);

            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = result
            };

        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ResultViewModel Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = FavRepo.Search(pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Data
            };
        }



        [HttpGet]
        [Authorize(Roles = "User")]

        public ResultViewModel Add()
        {
            List<TextValueViewModel> Values = FavRepo.GetFavID();
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = Values
            };

        }

        [HttpPost]
        //[Authorize(Roles = "User")]

        public ResultViewModel Add([FromBody]FavEditViewModelExtentions model)
        {
            var res = FavRepo.GetList().FirstOrDefault(i => i.Recipe_ID == model.Recipe_ID);
            if (res == null)
            {
                if (ModelState.IsValid == true)
                {
                    FavRepo.Add(model);
                    UnitOfWork.Save();
                    return new ResultViewModel()
                    {
                        Message = "Added Succesfully",
                        Success = true,
                        Data = true
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
                        Message = "Added Succesfully",
                        Success = false,
                        Data = false
                    };
                }
            }
            else
            {
                return new ResultViewModel { Data = false, Success = true };
            }
        }







        [HttpPost]
        public ResultViewModel Remove([FromBody]FavEditViewModelExtentions model)
        {
            var res = FavRepo.Remove(model);
            UnitOfWork.Save();
            return new ResultViewModel()
            {
                Success = true,
                Message = "Removed Succesfully",
                Data = null
            };
 
            
        }

    }
}
