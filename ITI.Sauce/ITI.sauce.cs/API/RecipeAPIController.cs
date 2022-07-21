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
       

        public RecipeAPIController(RecipeRepository _RecipeRepo)
        {
            this.RecipeRepo = _RecipeRepo;
          
        }

        //[Authorize(Roles = "Admin,User,Vendor")]
        [HttpGet]
        public ResultViewModel GetAPI(string NameAr = null, string NameEN = null,
            string orderBy = null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20)
        {
            var data = RecipeRepo.Get(
                NameAr, NameEN, orderBy, ImageUrl, VideoUrl,
                isAscending, Price, rdate, category, pageIndex, pageSize);
            return new ResultViewModel()
            {
                Success = true,
                Message = "",
                Data = data
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

