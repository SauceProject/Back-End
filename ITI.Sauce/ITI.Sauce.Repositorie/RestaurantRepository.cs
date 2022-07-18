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
    public class RestaurantRepository : GeneralRepository<Restaurant>
    {
        public RestaurantRepository(DBContext _Context) : base(_Context)
        {

        }
        public IPagedList<RestaurantViewModel> Get(string Vendor_ID="", int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Restaurant>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(U => U.ID == id);
            if (!string.IsNullOrEmpty(Vendor_ID))
                filter = filter.Or(U => U.Vendor_ID == Vendor_ID);
            if (WorkTime != null)
                filter = filter.Or(d => d.WorkTime <= WorkTime);
            if (!string.IsNullOrEmpty(NameEn))
                filter = filter.Or(NEn => NEn.NameEN.Contains(NameEn));
            if (!string.IsNullOrEmpty(NameAr))
                filter = filter.Or(NAR => NAR.NameAR.Contains(NameAr));
            if (registerDate != null)
                filter.Or(d => d.RegisterDate <= registerDate);
            if (isDeleted != false)
                filter = filter.Or(d => d.IsDeleted == isDeleted);
            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );

            var result =
            query.Select(V => new RestaurantViewModel
            {
                ID = V.ID,
                WorkTime = V.WorkTime,
                NameEN = V.NameEN,
                NameAR = V.NameAR,
                RegisterDate = V.RegisterDate,
                IsDeleted = V.IsDeleted,
            }).ToPagedList(pageIndex, pageSize);
            return result;

            //PaginingViewModel<List<RestaurantViewModel>>

            //    finalResult = new PaginingViewModel<List<RestaurantViewModel>>()
            //    {
            //        PageIndex = pageIndex,
            //        PageSize = pageSize,
            //        Count = base.GetList().Count(),
            //        Data = result.ToList()
            //    };
            //return finalResult;

        }

            public IPagedList<RestaurantViewModel> Search(int pageIndex = 1, int pageSize = 2)
                       =>
       GetList().Select(V => new RestaurantViewModel
       {
           ID = V.ID,
           WorkTime = V.WorkTime,
           NameEN = V.NameEN,
           NameAR = V.NameAR,
           RegisterDate = V.RegisterDate,
           IsDeleted = V.IsDeleted,
       }).ToPagedList(pageIndex, pageSize);

        public RestaurantViewModel Add(RestaurantEditViewModel model)
        {
            Restaurant restaurant = model.ToModel();
            return base.Add(restaurant).Entity.ToViewModel();
        }

        public List<TextValueViewModel> GetCRestaurantDropDown() =>
          GetList().Select(i => new TextValueViewModel
          {
              Value = i.ID,
              Text = i.NameEN
          }).ToList();






        public RestaurantViewModel Update(RestaurantEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Restaurant>();
            var old = filterd;
            filterd = filterd.Or(V => V.ID == model.ID);
            var Result = base.GetByID(filterd);
            Result.ID = model.ID;
            Result.WorkTime = model.WorkTime;
            Result.NameEN = model.NameEN;
            Result.NameAR = model.NameAR;
            Result.RegisterDate = model.RegisterDate;
            Result.IsDeleted = model.IsDeleted;
            return Result.ToViewModel();
        }
        public RestaurantViewModel GetOne(int _ID = 0)
        {
            var filterd = PredicateBuilder.New<Restaurant>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(V => V.ID == _ID);
            if (old == filterd)
                filterd = null;
            var query = base.GetByID(filterd);
            return query.ToViewModel();

        }





        public RestaurantViewModel Remove(RestaurantEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Restaurant>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.ID);


            var Result = base.GetByID(filterd);

            Result.IsDeleted = true;

            return Result.ToViewModel();


        }

    }
}
