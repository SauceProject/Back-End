using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Abp.Linq.Expressions;

namespace ITI.Sauce.Repository
{
    public class IngredientRepository : GeneralRepository<Ingredient>
    {
        public IngredientRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<IngredientViewModel>> Get (int ID =0,string orderBy = null, 
            bool isAscending = false , string NameEN = "",
            string NameAR = "", string ImageUrl="" ,int pageIndex=1, int pageSize= 20)
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
            filter = filter.Or(I => I.IsDeleted == false);

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

        public IngredientViewModel Add(IngredientEditViewModel model)
        {
            Ingredient ingredient = model.ToModel();
            return base.Add(ingredient).Entity.ToViewModel();
        }







        public IngredientViewModel Update(IngredientEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Ingredient>();
            var old = filterd;

            filterd = filterd.Or(i => i.ID == model.ID);

            var Result = base.GetByID(filterd);
            Result.NameEN = model.NameEN;
            Result.NameAR = model.NameAR;
            Result.ImageUrl = model.ImageUrl;

            return Result.ToViewModel();


        }
        public IngredientViewModel GetOne(int _ID = 0)
        {



            var filterd = PredicateBuilder.New<Ingredient>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(i => i.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);


            return query.ToViewModel();



        }




        public IngredientViewModel Remove(IngredientEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Ingredient>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.ID);


            var Result = base.GetByID(filterd);

            Result.IsDeleted = true;

            return Result.ToViewModel();


        }

    }

}
