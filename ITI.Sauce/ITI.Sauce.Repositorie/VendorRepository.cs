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
        private readonly Vendor_MembershipRepository vendorMemberRepo;
        private readonly MemberShipRepository memberShipRepository;


        public VendorRepository(DBContext _Context, Vendor_MembershipRepository _vendorMemberRepo,
            MemberShipRepository _memberShipRepository)
            : base(_Context)
        {
            vendorMemberRepo = _vendorMemberRepo;
            memberShipRepository = _memberShipRepository;


        }
        public PaginingViewModel<List<VendorViewModel>> Get(string id = "",
            string nameEN = "", string nameAR = "", string Email = "", string phone = "",
                string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 5)
        {

            var filter = PredicateBuilder.New<Vendor>();
            var oldFiler = filter;
           
            if (!string.IsNullOrEmpty(id))
                filter = filter.Or(V => V.ID == id);
            if (!string.IsNullOrEmpty(nameEN))
                filter = filter.Or(V => V.User.NameEN.Contains(nameEN));
            
            if (!string.IsNullOrEmpty(nameAR))
                filter = filter.Or(V => V.User.NameAR.Contains(nameAR));
            if (!string.IsNullOrEmpty(Email))
                filter = filter.Or(V => V.User.Email.Contains(Email));
            if (!string.IsNullOrEmpty(phone))
                filter = filter.Or(V => V.User.PhoneNumber.Any(i => i.Equals(phone)));

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize, "Vendor_MemberShips");

            

            var result =
            query.Select(V => new VendorViewModel
            {
                ID = V.ID,
                UserName = V.User.UserName,
               
                NameEN = V.User.NameEN,
                NameAR = V.User.NameAR,
                Email = V.User.Email,
                IsDeleted = V.IsDeleted,
                phones = V.User.PhoneNumber,
                MemberShips= getMemberShipName(V.Vendor_MemberShips),

            }).ToList();

            PaginingViewModel<List<VendorViewModel>>
                finalResult = new PaginingViewModel<List<VendorViewModel>>()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Count = base.GetList().Count(),
                    Data = result,
                };


            return finalResult;
        }


        public IPagedList<VendorViewModel> Search(int pageIndex = 1, int pageSize = 2)
                    =>
                GetList().Select(V => new VendorViewModel
                {
                    ID = V.ID,
                    UserName = V.User.UserName,

                    NameEN = V.User.NameEN,
                    NameAR = V.User.NameAR,
                    Email = V.User.Email,
                    IsDeleted = V.IsDeleted,
                    phones = V.User.PhoneNumber,
                    

                }).ToPagedList(pageIndex, pageSize);

        public VendorViewModel Add(VendorEditViewModel model)
        {
            /////
            Vendor Vendor = model.ToModel();
            return base.Add(Vendor).Entity.ToViewModel();
        }


        public VendorViewModel Update(VendorEditViewModel model)
        {

            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;

            filterd = filterd.Or(i => i.ID == model.Id);

            var Result = base.GetByID(filterd);
            
            Result.User.UserName = model.UserName;
            
            Result.User.NameEN = model.NameEN;
            Result.User.NameAR = model.NameAR;
            Result.User.Email = model.Email;
            return Result.ToViewModel();


        }
        public VendorViewModel GetOne(string _ID = "")
        {
            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;
            if (!string.IsNullOrEmpty(_ID))
                filterd = filterd.Or(i => i.ID == _ID);

            if (old == filterd)
                filterd = null;

            var query = base.GetByID(filterd);

            return new VendorViewModel
            {
                ID = query.ID,
                UserName = query.User.UserName,
                
                NameEN = query.User.NameEN,
                NameAR = query.User.NameAR,
                Email = query.User.Email,
                phones = query.User.PhoneNumber,

                MemberShips = getMemberShipName(query.Vendor_MemberShips),


            }; ;
        }

        public VendorViewModel Remove(string Id)
        {

            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;

            filterd = filterd.Or(c => c.ID == Id);
            var Result = base.GetByID(filterd);

            Result.IsDeleted = true;

            return Result.ToViewModel();
        }
       

public VendorViewModel AcceptVendor (string ID)
        {
            var filterd = PredicateBuilder.New<Vendor>();
            var old = filterd;
            if (!string.IsNullOrEmpty(ID))
                filterd = filterd.Or(i => i.ID == ID);

            if (old == filterd)
                filterd = null;

            var vendor = base.GetByID(filterd);
            vendor.IsDeleted = false;
            return base.Update(vendor).Entity.ToViewModel();
        }



    List<MemberShipViewModel> getMemberShipName(List<Vendor_MemberShip> vendorMemberShips)
    {
            var res = new List<MemberShipViewModel>();
            foreach(var item in vendorMemberShips)
            {
                res.Add(memberShipRepository.GetOne(item.MemberShip_ID));
            }
           return res;
    }
    }

}
