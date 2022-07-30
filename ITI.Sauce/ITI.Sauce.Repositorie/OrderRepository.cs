
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;

using X.PagedList;
using ITI.Sauce.ViewModels.Shared;

namespace ITI.Sauce.Repository
{
    public class OrderRepository : GeneralRepository<Order>
    {
        UnitOfWork unitOfWork;
        public OrderRepository(DBContext _Context, UnitOfWork unitOfWork) : base(_Context)
        {
            this.unitOfWork = unitOfWork;
        }
        public IPagedList<OrderViewModel> Get(int ID = 0, string orderBy = null
            , bool isAscending = false, string UserId = "", DateTime? registerDate =null ,
             int pageIndex = 1, int pageSize = 20)
                    
        {
            
            var filter = PredicateBuilder.New<Order>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(o => o.ID == ID);
         
            if (!string.IsNullOrEmpty(UserId))
                filter = filter.Or(o => o.UserId.Contains(UserId));
            if (registerDate != null) 
                filter = filter.Or(o => o.OrderDate.Year == registerDate.Value.Year);
            
            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize, "orderLists") ;


            var result =
            query.Select(i => new OrderViewModel
            {
                ID = i.ID,
                UserId = i.UserId,
                
                IsDeleted=i.IsDeleted,
                OrderDate=i.OrderDate,
                orderLists=i.orderLists

            }).ToPagedList(pageIndex, pageSize);

            //PaginingViewModel<List<OrderViewModel>>
            //   finalResult = new PaginingViewModel<List<OrderViewModel>>()
            //   {
            //       PageIndex = pageIndex,
            //       PageSize = pageSize,
            //       Count = base.GetList().Count(),
            //       Data = result.ToList()
            //   };


            return result;
        }

        public PaginingViewModel<List<OrderViewModel>> GetAPI(int ID = 0, string orderBy = null
            , bool isAscending = false, string UserId = "", DateTime? registerDate = null,
             int pageIndex = 1, int pageSize = 20)

        {

            var filter = PredicateBuilder.New<Order>();
            var oldFiler = filter;
            if (ID > 0)
                filter = filter.Or(o => o.ID == ID);

            if (!string.IsNullOrEmpty(UserId))
                filter = filter.Or(o => o.UserId.Contains(UserId));
            if (registerDate != null)
                filter = filter.Or(o => o.OrderDate.Year == registerDate.Value.Year);

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderBy, isAscending, pageIndex, pageSize, "orderLists");


            var result =
            query.Select(i => new OrderViewModel
            {
                ID = i.ID,
                UserId = i.UserId,

                IsDeleted = i.IsDeleted,
                OrderDate = i.OrderDate,
                orderLists = i.orderLists

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



        public IPagedList<OrderViewModel> Search(int pageIndex = 1, int pageSize = 2)
                   =>
   GetList().Select(V => new OrderViewModel
   {
       ID = V.ID,
       UserId = V.UserId,

       IsDeleted = V.IsDeleted,
       OrderDate = V.OrderDate,

   }).ToPagedList(pageIndex, pageSize);

        public OrderViewModel Add(OrderEditViewModel model)
        {
            Order Order = model.ToModel();
            var res = base.Add(Order).Entity.ToViewModel();
            unitOfWork.Save();

            return res;
        }

        //public List<TextValueViewModel> GetRecipeID() =>
        //   GetList().Select(i => new TextValueViewModel
        //   {
        //       Value =i.Recipe_ID
        //   }).ToList();
        public OrderViewModel Update(OrderEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Order>();
            var old = filterd;

            filterd = filterd.Or(i => i.ID == model.ID);

            var Result = base.GetByID(filterd);
            Result.ID = model.ID;
            Result.UserId = model.UserId;
            Result.IsDeleted=model.IsDeleted;
            Result.OrderDate= model.OrderDate;
           

            return Result.ToViewModel();


        }
        public OrderViewModel GetOne(int _ID = 0)
        {
            var filterd = PredicateBuilder.New<Order>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(i => i.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);
            return query.ToViewModel();
        }

        public OrderViewModel Remove(OrderEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Order>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == model.ID);


            var Result = base.GetByID(filterd);

            Result.IsDeleted = true;

            return Result.ToViewModel();


        }

    }
}
