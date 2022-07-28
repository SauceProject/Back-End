
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
    public class OrderListRepository : GeneralRepository<OrderList>
    {
        private readonly UnitOfWork unitOfWork;

        public OrderListRepository(DBContext _Context,UnitOfWork _unitOfWork) : base(_Context)
        {
            unitOfWork = _unitOfWork;

        }
        public PaginingViewModel<List<OrderListViewModel>> Get(int ID = 0, string orderBy = null
            ,int OrderListQty=0, bool isAscending = false
            , int pageIndex = 1, int pageSize = 20)

        {

            var filter = PredicateBuilder.New<OrderList>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(o => o.OrderListID == ID);
            if (OrderListQty > 0)
                filter = filter.Or(o => o.OrderListQty == OrderListQty);



            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);


            var result =
            query.Select(i => new OrderListViewModel
            {
                OrderListID = i.OrderListID,
                OrderListQty=i.OrderListID,


            });

            PaginingViewModel<List<OrderListViewModel>>
               finalResult = new PaginingViewModel<List<OrderListViewModel>>()
               {
                   PageIndex = pageIndex,
                   PageSize = pageSize,
                   Count = base.GetList().Count(),
                   Data = result.ToList()
               };


            return finalResult;
        }

        public PaginingViewModel<List<OrderListViewModel>> GetByOrderID( int OrderID=0, bool isAscending = false,
           string orderBy = null, int pageIndex = 1, int pageSize = 20)

        {

            var filter = PredicateBuilder.New<OrderList>();
            var oldFiler = filter;
            if (OrderID > 0)
                filter = filter.Or(o => o.OrderID == OrderID);
        

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize);


            var result =
            query.Select(i => new OrderListViewModel
            {
                OrderListID = i.OrderListID,
                OrderListQty = i.OrderListID,
                OrderListPrice=i.OrderListPrice,
                RecipeID=i.Recipe_ID

            });

            PaginingViewModel<List<OrderListViewModel>>
               finalResult = new PaginingViewModel<List<OrderListViewModel>>()
               {
                   PageIndex = pageIndex,
                   PageSize = pageSize,
                   Count = base.GetList().Count(),
                   Data = result.ToList()
               };


            return finalResult;
        }

        public OrderListViewModel Add(OrderListEditViewModel model)
        {
            var cart = model.ToModel();
            var result = base.Add(cart);
            unitOfWork.Save();
            return result.Entity.ToViewModel();
        }

    }
}
