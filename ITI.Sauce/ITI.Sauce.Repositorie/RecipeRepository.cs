using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                NameEN = i.NameEN,
                CategoryName=i.Category.NameEN
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
        

    }
}
