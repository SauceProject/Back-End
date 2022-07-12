using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
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
        public ObjectResult Get(string NameAr = null, string NameEN = null,
            string orderBy = null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price = 0, DateTime? rdate = null, string category = null,
            int pageIndex = 1, int pageSize = 20)
        {
            var data = RecipeRepo.Get(
                NameAr, NameEN, orderBy, ImageUrl, VideoUrl,
                isAscending, Price, rdate, category, pageIndex, pageSize);
            return new ObjectResult(data);
        }
        //[Authorize(Roles = "Admin,Vendor")]
        public IActionResult Search(int pageIndex = 1, int pageSize = 2)
        {
            var Data = RecipeRepo.Search(pageIndex, pageSize);
            return new ObjectResult(Data);
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
        



       

    }
}

