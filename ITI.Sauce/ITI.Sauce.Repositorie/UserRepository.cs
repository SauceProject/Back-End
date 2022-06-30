using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Linq.Expressions;

using X.PagedList;
using Microsoft.AspNetCore.Identity;

using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;

namespace ITI.Sauce.Repository
{
    public class UserRepository : GeneralRepository<Users>
    {
        UserManager<Users> userManger;
        SignInManager<Users> SignInManger;
        public UserRepository(DBContext _Context,
            UserManager<Users> _userManger, SignInManager<Users> _SignInManger) : base(_Context)
        {
            userManger = _userManger;
            SignInManger = _SignInManger;
        }
        public PaginingViewModel<List<UsersViewModel>> Get(string id = "", string UserName = "", string Email = "", string phone = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Users>();
            var oldFiler = filter;
            if (!string.IsNullOrEmpty(id))
                filter.Or(U => U.Id == id);
            if (!string.IsNullOrEmpty(UserName))
                filter.Or(U => U.UserName.Contains(UserName));
            if (!string.IsNullOrEmpty(Email))
                filter.Or(U => U.Email.Contains(Email));
            if (!string.IsNullOrEmpty(phone))
                filter = filter.Or(U => U.PhoneNumber == phone);
            if (!string.IsNullOrEmpty(NameEn))
                filter = filter.Or(NEn => NEn.NameEN.Contains(NameEn));
            if (!string.IsNullOrEmpty(NameAr))
                filter = filter.Or(NAR => NAR.NameAR.Contains(NameAr));
            if (registerDate != null)
                filter.Or(d => d.registerDate <= registerDate);

            if (filter == oldFiler)
                filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );
            var result = query.Select(i => new UsersViewModel
            {
                ID = i.Id,
                UserName = i.UserName,
                Email = i.Email,
                phone = i.PhoneNumber,
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
        public async Task<IdentityResult> SignUp(UserEditViewModel model) =>
             await userManger.CreateAsync(model.ToModel(), model.Password);

        public async Task<SignInResult> SignIn(UserLoginViewModel model) =>
            await SignInManger.PasswordSignInAsync(model.Email, model.Password,
                model.RemmeberMe, false);

        public async Task SignOut() =>
            await SignInManger.SignOutAsync();
        
        


     

        public IPagedList<UsersViewModel> Search(int pageIndex = 1, int pageSize = 2)
                   =>
   GetList().Select(i => new UsersViewModel
   {
       ID = i.Id,
       UserName = i.UserName,
       Email = i.Email,
       Password = i.PasswordHash,
       phone = i.PhoneNumber,
       registerDate = i.registerDate,
       NameEN = i.NameEN,
       IsDelete = i.IsDelete
   }).ToPagedList(pageIndex, pageSize);
        public UsersViewModel Add(UserEditViewModel model)
        {
            Users Users = model.ToModel();
            return base.Add(Users).Entity.ToViewModel();
        }
    }
}
