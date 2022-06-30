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
        public RecipeRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<RecipeViewModel>> Get ( 
            string NameAr=null, string NameEN=null,string orderBy=null,
            bool isAscending = false, float Price=0,DateTime? rdate=null , string category=null ,
            int pageIndex=1,int pageSize=20
            )
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
                ImageUrl = i.ImageUrl,
                IsDeleted = i.IsDeleted,
                NameAR = i.NameAR,
                NameEN = i.NameEN,
                Price = i.Price,
                RegisterDate = i.RegisterDate,
                VideoUrl = i.VideoUrl,
            });

            PaginingViewModel<List<RecipeViewModel>>
                finalResult = new PaginingViewModel<List<RecipeViewModel>>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Count = base.GetList().Count(),
                    Data = result.ToList()
                };
            return finalResult;

        }
        public IPagedList<RecipeViewModel> Search(int pageIndex = 1, int pageSize = 2)
                 =>
 GetList().Select(V => new RecipeViewModel
 {
     ID = V.ID,
     CategoryID = V.CategoryID,
     Details = V.Details,
     GoodFor = V.GoodFor,
     ImageUrl = V.ImageUrl,
     IsDeleted = V.IsDeleted,
     NameAR = V.NameAR,
     NameEN = V.NameEN,
     Price = V.Price,
     RegisterDate = V.RegisterDate,
     VideoUrl = V.VideoUrl,

 }).ToPagedList(pageIndex, pageSize);

        public RecipeViewModel Add(RecipeEditViewModel model)
        {
            Recipe Recipe = model.ToModel();
            return base.Add(Recipe).Entity.ToViewModel();
        }

        public List<TextValueViewModel> GetCategoryID() =>
           GetList().Select(i => new TextValueViewModel
           {
               Value = i.CategoryID
           }).ToList();

    }
}
