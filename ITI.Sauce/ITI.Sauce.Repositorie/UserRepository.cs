﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;
using ITI.Sauce.Services;
using Castle.Core.Configuration;
using Abp.Linq.Expressions;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using ITI.Sauce.ViewModels.Shared;

namespace ITI.Sauce.Repository
{
    public class UserRepository : GeneralRepository<Users>
    {
        UserManager<Users> userManger;
        SignInManager<Users> SignInManger;
        //EmailServices EmailServices;
        IConfiguration Configuration;
        public UserRepository(DBContext _Context,
            UserManager<Users> _userManger, SignInManager<Users> _SignInManger ,  IConfiguration _Configuration) : base(_Context)
           
        {
            userManger = _userManger;
            SignInManger = _SignInManger;
           // EmailServices = _EmailServices;
            Configuration = _Configuration;
          
        }
        public PaginingViewModel<List<UsersViewModel>> Get(string id = "", string UserName = "", string Email = "", string phones = "", DateTime? registerDate = null, string NameEn = "", string NameAr = "", string orderby = "ID", bool isAscending = false, int pageIndex = 1,
                        int pageSize = 20)
        {

            var filter = PredicateBuilder.New<Users>();
            var oldFiler = filter;
            if (!string.IsNullOrEmpty(id))
                filter=filter.Or(U => U.Id == id);
            if (!string.IsNullOrEmpty(UserName))
                filter = filter.Or(U => U.UserName.Contains(UserName));
            if (!string.IsNullOrEmpty(Email))
                filter = filter.Or(U => U.Email.Contains(Email));
            if (!string.IsNullOrEmpty(phones))
                filter = filter.Or(U => U.PhoneNumber == phones);
            if (!string.IsNullOrEmpty(NameEn))
                filter = filter.Or(NEn => NEn.NameEN.Contains(NameEn));
            if (!string.IsNullOrEmpty(NameAr))
                filter = filter.Or(NAR => NAR.NameAR.Contains(NameAr));
            if (registerDate != null)
                filter.Or(d => d.registerDate <= registerDate);

            if (filter == oldFiler)
                filter = filter = null;
            var query = base.Get(filter, orderby, isAscending, pageIndex, pageSize
                );
            var result = query.Select(i => new UsersViewModel
            {
                ID = i.Id,

                Email = i.Email,
                phone = i.PhoneNumber,
                registerDate = i.registerDate,
                NameEN = i.NameEN,
                NameAR = i.NameAR,


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
        public async Task<AccountResultViewModel> SignUp(UserEditViewModel model)
        {
            Users User = model.ToModel();
           var result =  await userManger.CreateAsync(User, model.Password);
            if (result.Succeeded)
            {
                result = await userManger.AddToRoleAsync(User, model.Role);
                if (result.Succeeded)
                {
                    //string token = await userManger.GenerateEmailConfirmationTokenAsync(User);
                    //string PathOfRedirectOfConfirmation
                    //=String.Format(Configuration.GetSection("Application:AppDomin").Value
                    //+Configuration.GetSection("Application:ConfirmationEmail").Value
                    //,User.Id , token);
                    //SendEmailOptions options = new SendEmailOptions()
                    //{
                    //    Subject = "Confirmation Email",
                    //    FromEmail = "Info@SauceMang.com",
                    //    FromEmailDisplayName = "Sauce App",
                    //    IsBodyHTML = true,
                    //    Body = SendEmailOptions.GenerateBodyFromTemplate("ConfirmEmail",
                    //    new Dictionary<string, string>()
                    //    {
                    //        {"{{UserName}}",  User.NameEN},
                    //        {"{{Link}}" ,PathOfRedirectOfConfirmation  }
                    //    })
                    //};
                    //options.ToEmails.Add(User.Email);
                    //await EmailServices.SendEmail(options);
                    return new AccountResultViewModel { IsSuccess = result.Succeeded, UserId = User.Id, Errors =null};

                }
            }
            return new AccountResultViewModel { IsSuccess= result.Succeeded,UserId=User.Id,Errors = result.Errors};

        }
        public async Task<String> SignIn(UserLoginViewModel model)
        { 
            var result=await SignInManger.PasswordSignInAsync(model.Email, model.Password,
                model.RemmeberMe, false);
            if (result.Succeeded)
            {
                Users user = await  userManger.FindByEmailAsync(model.Email);
                List<Claim> claims = new List<Claim>();
                IList<string> roles= await userManger.GetRolesAsync(user);
                roles.ToList().ForEach(i => claims.Add(new Claim(ClaimTypes.Role, i)));
                JwtSecurityToken token
                     = new JwtSecurityToken
                     (
                       signingCredentials: new SigningCredentials
                         (
                             new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT:Key"]))
                             , SecurityAlgorithms.HmacSha256
                         ),
                       expires: DateTime.Now.AddDays(1),
                        claims:claims
                     );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return string.Empty;
        }

        public async Task SignOut() =>
            await SignInManger.SignOutAsync();
        
        public IPagedList<UsersViewModel> Search(int pageIndex = 1, int pageSize = 2)
                   =>
               GetList().Where(v => v.Vendor == null).Select(i => new UsersViewModel
               {
                   ID = i.Id,
                   Email = i.Email,
                   Password = i.PasswordHash,
                   phone = i.PhoneNumber,
                   registerDate = i.registerDate,
                   NameEN = i.NameEN,
                   IsDelete = i.IsDelete,
                   NameAR = i.NameAR,
               }).ToPagedList(pageIndex, pageSize);
        public UsersViewModel Add(UserEditViewModel model)
        {
            Users Users = model.ToModel();
            return base.Add(Users).Entity.ToViewModel();
        }
        public Task<Users> getbyEmail(string email)
        {
            return userManger.FindByNameAsync(email);
        }


       

        public async Task<IdentityResult> ChangePassward(ChangePasswardViewModel model)
        {
            Users users = await userManger.FindByIdAsync(model.Id);
         var result =  await userManger.ChangePasswordAsync(users, model.CurrentPassword, model.NewPassword);
            return result;
        }


        public async Task<IdentityResult> ConfirmEmail(string Id, string token) =>
             await userManger.ConfirmEmailAsync(await userManger.FindByIdAsync(Id), token);



        public async Task<IdentityResult> Update(UsersViewModel result)
        {
            var filter = PredicateBuilder.New<Users>();
            filter = filter.Or(p => p.Id == result.ID);
            var last = GetByID(filter);
            last.NameEN = result.NameEN;
            last.NameAR = result.NameAR;
            last.UserName = result.Email;
            last.PhoneNumber = result.phone;
           

            return await userManger.UpdateAsync(last);
        }

    }


}
