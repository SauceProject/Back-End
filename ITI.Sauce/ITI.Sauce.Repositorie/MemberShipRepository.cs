using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;
using Abp.Linq.Expressions;
using X.PagedList;
using static ITI.Sauce.ViewModels.MemberShipExtentions;

namespace ITI.Sauce.Repository
{
    public class MemberShipRepository : GeneralRepository<MemberShip>
    {
        public MemberShipRepository(DBContext _Context) : base(_Context)
        {

        }


       
        public PaginingViewModel<List<MemberShipViewModel>> Get(int id = 0, float Price = 0 , string TypeEn="",string TypeAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                         int pageSize = 20)
        {
            var filter = PredicateBuilder.New<MemberShip>();
            var oldFiler = filter;
            if (id > 0)
                filter.Or(U => U.ID == id);
            if (Price > 0)
                filter = filter.Or(r => r.Price <= Price);
            if (!string.IsNullOrEmpty(TypeEn))
                filter.Or(U => U.TypeEn.Contains(TypeEn));
            if (!string.IsNullOrEmpty(TypeAr))
                filter.Or(U => U.TypeAr.Contains(TypeAr));
            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );
            var result = query.Select(i => new MemberShipViewModel
            {
                ID = i.ID,
                
                TypeEn = i.TypeEn,
                TypeAr = i.TypeAr,
                Price = i.Price,

            });
            PaginingViewModel<List<MemberShipViewModel>>
            finalResult = new PaginingViewModel<List<MemberShipViewModel>>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = base.GetList().Count(),
                Data = result.ToList()
            };

            return finalResult;

        }
        public IPagedList<MemberShipViewModel> Search(int pageIndex = 1, int pageSize = 2)
               =>
GetList().Select(i => new MemberShipViewModel
{
    ID = i.ID,

    TypeEn = i.TypeEn,
    TypeAr = i.TypeAr,
    Price = i.Price,

}).ToPagedList(pageIndex, pageSize);
        public MemberShipViewModel Add(MemberShipEditViewModel model)
        {
           MemberShip memberShip = model.ToModel();
            return base.Add(memberShip).Entity.ToViewModel();
        }
    }
}
