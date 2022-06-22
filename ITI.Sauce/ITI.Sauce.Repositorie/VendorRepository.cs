using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels.Shared;
using ITI.Sauce.ViewModels.Vendor;

namespace ITI.Sauce.Repositories
{
    public class VendorRepository
         : GeneralRepository<Vendor>
    {
        public PaginingViewModel<List<VendorViewModel>> Get(int id = 0, 
            string nameEN = "",string nameAR="",string Email="", string phone = "",
                string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Vendor>();
            var oldFiler = filter;
            if (id > 0)
                filter = filter.Or(V => V.ID == id);
            if (!string.IsNullOrEmpty(nameEN))
                filter = filter.Or(V => V.NameEN.Contains(nameEN));
            if (!string.IsNullOrEmpty(nameAR))
                filter = filter.Or(V => V.NameAR.Contains(nameAR));
            if (!string.IsNullOrEmpty(Email))
                filter = filter.Or(V => V.Email.Contains(Email));
            if (!string.IsNullOrEmpty(phone))
                filter = filter.Or(V => V.phone.Any(i => i.Equals(phone)));

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );

            var result =
            query.Select(V => new VendorViewModel
            {
                ID = V.ID,
                UserName=V.UserName,
                Password=V.Password,
                NameEN = V.NameEN,
                NameAR=V.NameAR,
                Email  =V.Email,
                IsDeleted = V.IsDeleted,
                phone = V.phone,
                
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
