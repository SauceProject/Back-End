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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace ITI.Sauce.Repository
{
    public class UserRepository : GeneralRepository<Users>
    {
        UserManager<Users> userManger;
        SignInManager<Users> SignInManger;
        IConfiguration configuration;
        public UserRepository(DBContext _Context,
            UserManager<Users> _userManger, SignInManager<Users> _SignInManger, IConfiguration _configuration) : base(_Context)
        {
            userManger = _userManger;
            SignInManger = _SignInManger;
            configuration = _configuration;
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
        public async Task<IdentityResult> SignUp(UserEditViewModel model)
        {
            Users User = model.ToModel();
           var result =  await userManger.CreateAsync(User, model.Password);
        result = await userManger.AddToRoleAsync(User, model.Role);
            return result;

        }
        public async Task<string> SignUpForVendor(UserEditViewModel model)
        {
            Users User = model.ToModel();
            var result = await userManger.CreateAsync(User, model.Password);
            result = await userManger.AddToRoleAsync(User, "Vendor");
            return User.Id;

        }
        public async Task<String> SignIn(UserLoginViewModel model)
        { 
            var result=await SignInManger.PasswordSignInAsync(model.Email, model.Password,
                model.RemmeberMe, false);
            if (result.Succeeded)
            {
                JwtSecurityToken token = new JwtSecurityToken
                    (
                        signingCredentials: new SigningCredentials
                    (
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Key"])),
                        SecurityAlgorithms.HmacSha256
                    ),
                        expires: DateTime.Now.AddDays(1)
                    );
              return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return String.Empty;
        }

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

     public async Task<IdentityResult> ChangePassward(ChangePasswardViewModel model)
        {
            Users users = await userManger.FindByIdAsync(model.Id);
         var result =  await userManger.ChangePasswordAsync(users, model.CurrentPassword, model.NewPassword);
            return result;
        }
    }
}
