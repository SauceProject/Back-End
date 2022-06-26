using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using ITI.Sauce.Repositories;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using ITI.Sauce.ViewModels.Ingredient;
using Abp.Linq.Expressions;

namespace ITI.Sauce.Repositorie
{
    public class IngredientRepository : GeneralRepository<Ingredient>
    {
        public IngredientRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<IngredientViewModel>> Get (int ID =0,string orderBy = null, 
            bool isAscending = false , string NameEN = "",
            string NameAR = "", string ImageUrl="" , int pageIndex=1, int pageSize= 20)
        {
            var filter = PredicateBuilder.New<Ingredient>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(I => I.ID == ID);
            if (!string.IsNullOrEmpty(NameEN))
                filter = filter.Or(I => I.NameEN.Contains(NameEN));
            if (!string.IsNullOrEmpty(NameAR))
                filter = filter.Or(I => I.NameAR.Contains (NameAR));
            if(!string.IsNullOrEmpty(ImageUrl))
                filter = filter.Or(I => I.ImageUrl.Contains(ImageUrl));
            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);

            var result =
                query.Select(i => new IngredientViewModel

                {
                    ID = i.ID,
                    NameEN = i.NameEN,
                    NameAR = i.NameAR,
                    ImageUrl = i.ImageUrl,
                });

            PaginingViewModel<List<IngredientViewModel>>
                finalResult = new PaginingViewModel<List<IngredientViewModel>>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Count = base.GetList().Count(),
                    Data = result.ToList(),
                };


            return finalResult;
        }
    }

}
