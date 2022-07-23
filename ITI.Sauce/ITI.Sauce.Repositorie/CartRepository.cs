using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Repository
{
    public class CartRepository : GeneralRepository<Cart>
    {
        private readonly UnitOfWork unitOfWork;
        public CartRepository (DBContext _dBContext, UnitOfWork _unitOfWork) 
            : base(_dBContext) {
            unitOfWork = _unitOfWork;
        }

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

        public CartViewModel Add(CartEditViewModel model)
        {
            var cart = model.ToModel();
            var result = base.Add(cart);
            unitOfWork.Save();
            return result.Entity.ToViewModel();
        }
        public CartViewModel Update(CartEditViewModel model)
        {
            var filterd = PredicateBuilder.New<Cart>();
            var old = filterd;
            if (model.ID > 0)
                filterd = filterd.Or(i => i.ID == model.ID);

            if (old == filterd)
                filterd = null;

            var cart = base.GetByID(filterd);

            cart.Qty = model.Qty;

            //recipe = model.ToModel();

            return base.Update(cart).Entity.ToViewModel();
            
        }
        public CartViewModel Remove (CartEditViewModel model)
        {
            var filterd = PredicateBuilder.New<Cart>();
            var old = filterd;
            if (model.ID > 0)
                filterd = filterd.Or(i => i.ID == model.ID);

            if (old == filterd)
                filterd = null;

            var cart = base.GetByID(filterd);
            var res = base.Remove(cart);
            unitOfWork.Save();

            return res.Entity.ToViewModel();
        }

    }
}
