using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;



namespace ITI.Sauce.Repository
{
    public class RestaurantRepository : GeneralRepository<Restaurant>
    {
        public RestaurantRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<RestaurantViewModel>> Get(int Vendor_ID =0,  int id = 0, DateTime? WorkTime = null, string NameEn = "", string NameAr = "", DateTime? registerDate = null, bool isDeleted = false, string orderby = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Restaurant>();
            var oldFiler = filter;
            if (id > 0)
                filter.Or(U => U.ID == id);
            if (Vendor_ID > 0)
                filter.Or(U => U.Vendor_ID == Vendor_ID);
            if (WorkTime != null)
                filter.Or(d => d.WorkTime <= WorkTime);
            
            if (!string.IsNullOrEmpty(NameEn))
                filter = filter.Or(NEn => NEn.NameEN.Contains(NameEn));
            if (!string.IsNullOrEmpty(NameAr))
                filter = filter.Or(NAR => NAR.NameAR.Contains(NameAr));
            if (registerDate != null)
                filter.Or(d => d.RegisterDate <= registerDate);
            if(isDeleted != false)
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
            });

            PaginingViewModel<List<RestaurantViewModel>>

                finalResult = new PaginingViewModel<List<RestaurantViewModel>>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Count = base.GetList().Count(),
                    Data = result.ToList()
                };
            return finalResult;


            return finalResult;
        }
    }
}
