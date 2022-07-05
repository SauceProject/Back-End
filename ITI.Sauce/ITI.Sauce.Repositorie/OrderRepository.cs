
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;

using X.PagedList;

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
                IsDeleted=i.IsDeleted,
                registerDate=i.registerDate,

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
       NameEN = V.NameEN,
       NameAR = V.NameAR,
       IsDeleted = V.IsDeleted,
       registerDate = V.registerDate,

   }).ToPagedList(pageIndex, pageSize);

        public OrderViewModel Add(OrderEditViewModel model)
        {
            Order Order = model.ToModel();
            return base.Add(Order).Entity.ToViewModel();
        }


        public OrderViewModel Update(OrderEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Order>();
            var old = filterd;

            filterd = filterd.Or(i => i.ID == model.ID);

            var Result = base.GetByID(filterd);
            Result.ID = model.ID;
            Result.NameEN = model.NameEN;
            Result.NameAR = model.NameAR;
            Result.IsDeleted=model.IsDeleted;
            Result.registerDate= model.registerDate;
           

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
