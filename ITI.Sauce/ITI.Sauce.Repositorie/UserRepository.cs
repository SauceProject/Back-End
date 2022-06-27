using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Linq.Expressions;
using Castle.Core.Internal;
using ITI.Sauce.Models;
using ITI.Sauce.ViewModels;


namespace ITI.Sauce.Repository
{
   public class UserRepository : GeneralRepository<Users>
    {
        public UserRepository(DBContext _Context) : base(_Context)
        {

        }
        public PaginingViewModel<List<UsersViewModel>> Get(int id = 0, string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null,  string NameEn = "" , string NameAr = "" , string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Users>();
            var oldFiler = filter;
            if (id > 0)
                filter.Or(U => U.ID == id);
            if(!string.IsNullOrEmpty(UserName))
                filter.Or(U => U.UserName.Contains(UserName));
            if(!string.IsNullOrEmpty(Email))
                filter.Or(U => U.Email.Contains(Email));
            if(!string.IsNullOrEmpty(phone))
                filter = filter.Or(U => U.phone == phone);
            if (!string.IsNullOrEmpty(NameEn))
                filter = filter.Or(NEn => NEn.NameEN.Contains(NameEn));
            if(!string.IsNullOrEmpty(NameAr))
                filter = filter.Or(NAR => NAR.NameAR.Contains(NameAr));
            if (registerDate != null)
                 filter.Or(d => d.registerDate<=registerDate);

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );
            var result = query.Select(i => new UsersViewModel
            {
                ID = i.ID,
                UserName = i.UserName,
                Email = i.Email,
                phone = i.phone,
                registerDate = i.registerDate,
                NameEN = i.NameEN,
               

            });


            PaginingViewModel<List<UsersViewModel>>
               finalResult = new PaginingViewModel<List<UsersViewModel>>()
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
