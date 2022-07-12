using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using ITI.Sauce.ViewModels.Cart;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Repository
{
    public class CartRepository : GeneralRepository<Cart>
    {
        public CartRepository (DBContext _dBContext) : base(_dBContext) { }

        public PaginingViewModel<List<CartViewModel>> Get( int ID=0,
            string orderBy = null, 
            bool isAscending = false, float Price = 0, DateTime? rdate = null,
            int pageIndex = 1, int pageSize = 20
            )
        {
            var filter = PredicateBuilder.New<Cart>();
            var oldFilter = filter;
            if (ID>0)
            {
                filter = filter.Or(c => c.ID == ID);
            }
            
            if (filter == oldFilter)
            {
                filter = null;
            }

            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);
            var result =
            query.Select(i => new CartViewModel
            {
                ID = i.ID,
                Recipe_ID=i.Recipe_ID,
                UserID=i.UserID,
                Qty=i.Qty
                
            });

            PaginingViewModel<List<CartViewModel>>
                finalResult = new PaginingViewModel<List<CartViewModel>>()
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
