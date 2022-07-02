using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Expressions;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;

using X.PagedList;

namespace ITI.Sauce.Repository
{
    public class VendorRepository
         : GeneralRepository<Vendor>
    {
        public VendorRepository(DBContext _Context)
            : base(_Context)
        {

        }
        public PaginingViewModel<List<VendorViewModel>> Get(int id = 0,
            string nameEN = "", string nameAR = "", string Email = "", string phone = "",
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
                UserName = V.UserName,
                Password = V.Password,
                NameEN = V.NameEN,
                NameAR = V.NameAR,
                Email = V.Email,
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
        public IPagedList<VendorViewModel> Search(int pageIndex = 1, int pageSize = 2)
                    =>
    GetList().Select(V => new VendorViewModel
    {
        ID = V.ID,
        UserName = V.UserName,
        Password = V.Password,
        NameEN = V.NameEN,
        NameAR = V.NameAR,
        Email = V.Email,
        IsDeleted = V.IsDeleted,
        phone = V.phone,

    }).ToPagedList(pageIndex, pageSize);

        public VendorViewModel Add(VendorEditViewModel model)
        {
            Vendor Vendor = model.ToModel();
            return base.Add(Vendor).Entity.ToViewModel();
        }


        public VendorViewModel Update(VendorEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;

            filterd = filterd.Or(i => i.ID == model.ID);

            var Result = base.GetByID(filterd);
            Result.ID = model.ID;
            Result.UserName = model.UserName;
            Result.Password = model.Password;
            Result.NameEN = model.NameEN;
            Result.NameAR = model.NameAR;
            Result.Email = model.Email;
            Result.phone = model.phone;

            return Result.ToViewModel();


        }
        public VendorViewModel GetOne(int _ID = 0)
        {



            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;
            if (_ID > 0)
                filterd = filterd.Or(i => i.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);


            return query.ToViewModel();



        }





    }

}
