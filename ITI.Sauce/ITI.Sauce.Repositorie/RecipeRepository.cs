using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ITI.Sauce.Repository
{
    public class RecipeRepository : GeneralRepository<Recipe>
    {
        RatingRepository rateRepo;
        public RecipeRepository(DBContext _Context,RatingRepository _rateRepo) : base(_Context)
        {
            this.rateRepo = _rateRepo;
        }
        public IPagedList<RecipeViewModel> Get( 
            string? NameAr=null, string? NameEN=null,string? orderBy=null, string ImageUrl = "", string VideoUrl = "",
            bool isAscending = false, float Price=0,DateTime? rdate=null , string? category=null ,
            int pageIndex=1,int pageSize=20, int RestaurantID =0)
        {
            var filter = PredicateBuilder.New<Recipe>();
            var oldFilter = filter;

            if (!string.IsNullOrEmpty(NameAr))
            {
               filter= filter.Or(r => r.NameAR.Contains(NameAr));
            }
            if(!string.IsNullOrEmpty( NameEN))
            {
                filter = filter.Or(r => r.NameEN.Contains(NameEN));
            }
            if (rdate != null)
            {
                filter = filter.Or(r => r.RegisterDate<=rdate);
            }
            if (Price>0)
            {
                filter = filter.Or(r => r.Price <= Price);
            }
            if (category!=null)
            {
                filter = filter.Or(r => r.Category.NameEN == category);
            }
            if (!string.IsNullOrEmpty(ImageUrl))
                filter = filter.Or(I => I.ImageUrl.Contains(ImageUrl));

            if (!string.IsNullOrEmpty(VideoUrl))
                filter = filter.Or(I => I.ImageUrl.Contains(VideoUrl));
            if (RestaurantID > 0)
            {
                filter = filter.Or(r => r.ResturantID == RestaurantID);
            }
            if (filter == oldFilter)
            {
                filter = null;
            }

            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);
            var result =
            query.Select(i => new RecipeViewModel
            {
                ID = i.ID,
                CategoryID = i.CategoryID,
                Details = i.Details,
                GoodFor = i.GoodFor,
                IsDeleted = i.IsDeleted,
                NameAR = i.NameAR,
                NameEN = i.NameEN,
                Price = i.Price,
                RegisterDate = i.RegisterDate,
                ImageUrl = i.ImageUrl,
                VideoUrl = i.VideoUrl,
                RestaurantName= i.Restaurant.NameEN,
                CategoryName = i.Category.NameEN,
                ResturantID = i.ResturantID,
            }).ToPagedList(pageIndex, pageSize);
            return result;


            //PaginingViewModel<List<RecipeViewModel>>
            //    finalResult = new PaginingViewModel<List<RecipeViewModel>>()
            //    {
            //        PageIndex = pageIndex,
            //        PageSize = pageSize,
            //        Count = base.GetList().Count(),
            //        Data = result.ToList()
            //    };
            //return finalResult;

        }
        public IPagedList<RecipeViewModel> Search(int pageIndex = 1, int pageSize = 2)
                 =>
 GetList().Select(V => new RecipeViewModel
 {
     ID = V.ID,
     CategoryID = V.CategoryID,
     Details = V.Details,
     GoodFor = V.GoodFor,
     IsDeleted = V.IsDeleted,
     NameAR = V.NameAR,
     NameEN = V.NameEN,
     Price = V.Price,
     RegisterDate = V.RegisterDate,
     ImageUrl = V.ImageUrl,
     VideoUrl = V.VideoUrl,
     RestaurantName = V.Restaurant.NameEN,
     CategoryName = V.Category.NameEN,
     ResturantID = V.ResturantID,

 }).ToPagedList(pageIndex, pageSize);

        public RecipeViewModel Add(RecipeEditViewModel model)
        {
            Recipe Recipe = model.ToModel();
            return base.Add(Recipe).Entity.ToViewModel();
        }
       

       

        public RecipeViewModel GetOne(int _ID = 0)
        {
            var filterd = PredicateBuilder.New<Recipe>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(i => i.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd,_ID);
            return query.ToViewModel();
        }

        public RecipeViewModel Update(RecipeEditViewModel model, int ID)
        {

            var filterd = PredicateBuilder.New<Recipe>();
            var old = filterd;
            if (ID > 0)
                filterd = filterd.Or(i => i.ID == ID);

            if (old == filterd)
                filterd = null;

            var recipe = base.GetByID(filterd);

            recipe.NameAR = model.NameAR;
            recipe.NameEN = model.NameEN;
            recipe.GoodFor = model.GoodFor;
            recipe.Price = model.Price;
            recipe.ImageUrl = model.ImageUrl;
            recipe.ResturantID = model.RestaurantID;
            recipe.CategoryID = model.CategoryID;
            recipe.Details = model.Details;

            //recipe = model.ToModel();

            return base.Update(recipe).Entity.ToViewModel();

        }

        public RecipeViewModel Remove(RecipeEditViewModel model,int ID)
        {
            var filterd = PredicateBuilder.New<Recipe>();
            var old = filterd;
            if (ID > 0)
                filterd = filterd.Or(i => i.ID == ID);

            if (old == filterd)
                filterd = null;

            var recipe = base.GetByID(filterd);
            recipe.IsDeleted = true;

            return base.Update(recipe).Entity.ToViewModel();

        }

        public RecipeViewModel AcceptRecipe(RecipeEditViewModel model, int ID)
        {
            var filterd = PredicateBuilder.New<Recipe>();
            var old = filterd;
            if (ID > 0)
                filterd = filterd.Or(i => i.ID == ID);

            if (old == filterd)
                filterd = null;

            var recipe = base.GetByID(filterd);
            recipe.IsDeleted = false;

            return base.Update(recipe).Entity.ToViewModel();

        }








       

        double getRateByRecipeId(int id)
        {
            var res = rateRepo.Get(0, 0, id);
           double val= res.Data.Average(r => r.RatingValue);
            return val;
        }

    }
}
