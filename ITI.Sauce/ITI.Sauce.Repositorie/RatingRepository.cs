using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Shared;
using X.PagedList;

namespace ITI.Sauce.Repository
{
    public class RatingRepository
         : GeneralRepository<Rating>
    {
        public RatingRepository(DBContext _Context) : base(_Context)
        {

        }
        public IPagedList<RatingViewModel> Get(int id = 0,
                    int RatingValue = 0,int? RecipeId=null,
                string orderby = "", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20 , int RestaurantID = 0)
        {

            var filter = PredicateBuilder.New<Rating>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(V => V.RatingID == id);
            if (RecipeId !=null)
                filter = filter.Or(V => V.RecipeID == RecipeId);

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );

            var result =
            query.Select(V => new RatingViewModel
            {
                RatingID = V.RatingID,
                RatingValue = V.RatingValue
            }).ToPagedList(pageIndex, pageSize); ;

            //PaginingViewModel<List<RatingViewModel>>
            //    finalResult = new PaginingViewModel<List<RatingViewModel>>()
            //    {
            //        PageIndex = pageIndex,
            //        PageSize = pageSize,
            //        Count = base.GetList().Count(),
            //        Data = result.ToList()
            //    };


            return result;
        }
        public IPagedList<RatingViewModel> Search(int pageIndex = 1, int pageSize = 2)
                    =>
    GetList().Select(V => new RatingViewModel
    {
        RatingID = V.RatingID,
        Comment = V.Comment,
        RatingValue = V.RatingValue,

    }).ToPagedList(pageIndex, pageSize);

        public RatingViewModel Add(RatingEditViewModel model)
        {
            Rating Rating = model.ToModel();
            return base.Add(Rating).Entity.ToViewModel();
        }

      

        public List<TextValueViewModel> GetRecipeID() =>
            GetList().Select(i => new TextValueViewModel
            {
                Value = i.RecipeID
            }).ToList();

        




        public RatingViewModel Update(RatingEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Rating>();
            var old = filterd;

            filterd = filterd.Or(c => c.RatingID == model.RatingID);

            var Result = base.GetByID(filterd);
            Result.Comment = model.Comment;
            Result.RatingValue = model.RatingValue;


            return Result.ToViewModel();


        }
        public RatingViewModel GetOne(int _ID = 0)
        {
            var filterd = PredicateBuilder.New<Rating>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(c => c.RatingID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);
            return query.ToViewModel();

        }

        public RatingViewModel Remove(RatingEditViewModel model)
        {
            var filterd = PredicateBuilder.New<Rating>();
            var old = filterd;
            filterd = filterd.Or(c => c.RatingID == model.RatingID);
            var Result = base.GetByID(filterd);
            Result.IsDeleted = true;
            return Result.ToViewModel();
        }
    }
}
