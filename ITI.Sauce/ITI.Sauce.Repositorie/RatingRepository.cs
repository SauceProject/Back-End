using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels.Rating;
using ITI.Sauce.ViewModels.Shared;

namespace ITI.Sauce.Repositories
{
    public class RatingRepository
         : GeneralRepository<Rating>
    {
        public RatingRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<RatingViewModel>> Get(int id = 0,
                    int RatingValue=0,
                string orderby = "", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Rating>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(V => V.RatingID == id);
            

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );

            var result =
            query.Select(V => new RatingViewModel
            {
                RatingID=V.RatingID,
                RatingValue=V.RatingValue
                
                

            });

            PaginingViewModel<List<RatingViewModel>>
                finalResult = new PaginingViewModel<List<RatingViewModel>>()
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
