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
using static ITI.Sauce.ViewModels.FavExtentions;

namespace ITI.Sauce.Repository
{
    public class FavRepository : GeneralRepository<Fav>
    {
        public FavRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<FavoriteViewModel>> Get(int Fav_ID = 0,
                string orderby = "", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Fav>();
            var oldFiler = filter;
            if (Fav_ID > 0)
                filter = filter.Or(V => V.ID == Fav_ID);


            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize,"Recipe"
                );

            var result =
            query.Select(V => new FavoriteViewModel
            {
                Fav_ID = V.ID,
                Recipe_ID=V.Recipe_ID

            });

            PaginingViewModel<List<FavoriteViewModel>>
                finalResult = new PaginingViewModel<List<FavoriteViewModel>>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Count = base.GetList().Count(),
                    Data = result.ToList()
                };


            return finalResult;
        }
        public IPagedList<FavoriteViewModel> Search(int pageIndex = 1, int pageSize = 2)
                    =>
    GetList().Select(V => new FavoriteViewModel
    {
        Fav_ID = V.ID,

    }).ToPagedList(pageIndex, pageSize);

        public FavoriteViewModel Add(FavEditViewModelExtentions model)
        {
            Fav Fav = model.ToModel();
            return base.Add(Fav).Entity.ToViewModel();
        }

        public List<TextValueViewModel> GetFavID() =>
            GetList().Select(i => new TextValueViewModel
            {
                Value = i.ID
            }).ToList();





        public FavoriteViewModel Update(FavEditViewModelExtentions model)
        {

            var filterd = PredicateBuilder.New<Fav>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.Fav_ID);

            var Result = base.GetByID(filterd);
            return Result.ToViewModel();


        }
        public FavoriteViewModel GetOne(int _ID = 0)
        {



            var filterd = PredicateBuilder.New<Fav>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(c => c.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);


            return query.ToViewModel();


        }

        public FavoriteViewModel Remove(FavEditViewModelExtentions model)
        {

            var filterd = PredicateBuilder.New<Fav>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.Fav_ID);


            var Result = base.GetByID(filterd);

            //Result.IsDeleted = true;
            var res = base.Remove(Result);

            return res.Entity.ToViewModel();
        }
    }
}

 
