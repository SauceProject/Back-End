
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Linq.Expressions;

namespace ITI.Sauce.Repository
{
    public class OrderRepository : GeneralRepository<Order>
    {
        public OrderRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<OrderViewModel>> Get(int ID = 0, string orderBy = null
            , bool isAscending = false, string NameEN = "",
            string NameAR = "", DateTime? registerDate =null 
            ,int pageIndex = 1, int pageSize = 20)
                    
        {
            
            var filter = PredicateBuilder.New<Order>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(o => o.ID == ID);
            if (!string.IsNullOrEmpty(NameEN))
                filter = filter.Or(o => o.NameEN.Contains(NameEN));
            if (!string.IsNullOrEmpty(NameAR))
                filter = filter.Or(o => o.NameAR.Contains(NameAR));
            if (registerDate != null) 
                filter = filter.Or(o => o.registerDate.Year == registerDate.Value.Year);
            
            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);


            var result =
            query.Select(i => new OrderViewModel
            {
                ID = i.ID,
                NameEN = i.NameEN,
                NameAR = i.NameAR,
                registerDate = i.registerDate.ToLongTimeString(),

            });

            PaginingViewModel<List<OrderViewModel>>
               finalResult = new PaginingViewModel<List<OrderViewModel>>()
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
