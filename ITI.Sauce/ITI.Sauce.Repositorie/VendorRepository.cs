using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Library.ViewModels.Shared;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels.Vendor;

namespace ITI.Library.Repositories
{
    public class VendorRepository
         : GeneralRepository<Vendor>
    {
        public PaginingViewModel<List<VendorViewModel>> Get(int id = 0, string name = "", string phone = "",
                string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Vendor>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(V => V.ID == id);
            if (!string.IsNullOrEmpty(name))
                filter = filter.Or(V => V.NameEN.Contains(name));
            if (!string.IsNullOrEmpty(phone))
                filter = filter.Or(V => V.phone.Any(i => i.Equals(phone)));

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );

            var result =
            query.Select(i => new VendorViewModel
            {
                ID = i.ID,
                NameEN = i.NameEN,
                Email  =i.Email,
                IsDeleted = i.IsDeleted,
                phone=i.phone,
            });

            PaginingViewModel<List<VendorViewModel>>
                finalResult = new PaginingViewModel<List<VendorViewModel>>()
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
