using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI.Sauce.MVC.API
{
    public class RecipeAPIController : ControllerBase
    {
        private readonly RecipeRepository RecipeRepo;
        private readonly Recipe_IngredientRepository recipe_IngredientRepository;


        public RecipeAPIController(RecipeRepository _RecipeRepo, Recipe_IngredientRepository _recipe_IngredientRepository)
        {
            this.RecipeRepo = _RecipeRepo;
            recipe_IngredientRepository = _recipe_IngredientRepository;


        }

        //[Authorize(Roles = "Admin,User,Vendor")]
        [HttpGet]
        public ResultViewModel GetAPI(int ID=0,int ResturantID=0, string NameAr = null, string NameEN = null,
            string orderBy = null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20)
        {
            var data = RecipeRepo.GetAPI(ResturantID,
                NameAr, NameEN, orderBy, ImageUrl, VideoUrl,
                isAscending, Price, rdate, category, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

        public ResultViewModel GetDetails(int id)
        {
            var data = RecipeRepo.GetOne(
               id);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
            };
        }

        public ResultViewModel GetIngredient(int RecipeID)
        {
            ////var ingredient = RecipeRepo.GetOne(RecipeID);
            //var ingredient = RecipeRepo.GetOne(RecipeID);
            var res = recipe_IngredientRepository.GetIng(RecipeID);

            return new ResultViewModel
            {
                Data = res,
                Message="Done",
                Success=true
            };
        }
        private IEnumerable<SelectListItem> GetCateogriesNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
        }

        private IEnumerable<SelectListItem> GetRestaurantNames(List<TextValueViewModel> list)
        {
            return list.Select(i => new SelectListItem
            {
                Text = i.Text,
                Value = i.Value.ToString()
            });
        }




        public ResultViewModel GetByIngerdientAPI(int IngerdientId)
        {
            var res = recipe_IngredientRepository.GetRecipe(IngerdientId);

            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = res
            };
        }




        //[HttpGet]
        //private ResultViewModel Search(string Name ="", string orderBy = null, bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        //{
        //   var result = RecipeRepo.Search(Name,orderBy,isAscending,pageIndex,pageSize);
        //    return new ResultViewModel()
        //    {
        //        Success = true,
        //        Message = "",
        //        Data = result
        //    };

        //}




    }
}

