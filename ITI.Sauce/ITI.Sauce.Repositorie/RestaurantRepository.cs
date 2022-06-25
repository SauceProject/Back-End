using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels.Restaurant;
using ITI.Sauce.ViewModels.Shared;
using ITI.Sauce.ViewModels.Vendor;

namespace ITI.Sauce.Repositories
{
    public class RestaurantRepository
         : GeneralRepository<Restaurant>
    {
        public PaginingViewModel<List<RestaurantViewModel>> Get(int id = 0,
            string nameEN = "", string nameAR = "", 
                string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Restaurant>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(V => V.ID == id);
            if (!string.IsNullOrEmpty(nameEN))
                filter = filter.Or(V => V.NameEN.Contains(nameEN));
            if (!string.IsNullOrEmpty(nameAR))
                filter = filter.Or(V => V.NameAR.Contains(nameAR));

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
        }
    }
}
