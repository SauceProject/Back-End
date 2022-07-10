﻿
using ITI.Sauce.Models;
using ITI.Sauce.MVC.Helpers;
using ITI.Sauce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;


public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddControllersWithViews().AddNewtonsoftJson(optonis =>
        {
            optonis.SerializerSettings.Formatting=Newtonsoft.Json.Formatting.Indented;
            optonis.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });
        builder.Services.AddIdentity<Users, IdentityRole>().
            AddEntityFrameworkStores<DBContext>();
        builder.Services.AddScoped(typeof(VendorRepository));
        builder.Services.AddScoped(typeof(UserRepository));
        builder.Services.AddScoped(typeof(RestaurantRepository));
        builder.Services.AddScoped(typeof(RecipeRepository));
        builder.Services.AddScoped(typeof(RatingRepository));
        builder.Services.AddScoped(typeof(OrderRepository));
        builder.Services.AddScoped(typeof(MemberShipRepository));


        builder.Services.AddDbContext<DBContext>(i =>
        {
            i.UseLazyLoadingProxies().UseSqlServer
          (builder.Configuration.GetConnectionString("SauceDB"));
        });

        builder.Services.AddScoped(typeof(OrderListRepository));
        builder.Services.AddScoped(typeof(IngredientRepository));
        builder.Services.AddScoped(typeof(CategoryRepository));
        builder.Services.AddScoped(typeof(RoleRepository));
        builder.Services.AddScoped(typeof(DBContext));
        builder.Services.AddScoped(typeof(UnitOfWork));
        builder.Services.AddScoped<IUserClaimsPrincipalFactory<Users>, UserClaimsFactory>();
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        });
        //builder.Services.ConfigureApplicationCookie(Option =>
        //{
        //    Option.LoginPath = "/Users/SignUp";
        //});
        builder.Services.ConfigureApplicationCookie(Option =>
        {
            Option.LoginPath = "/UserAPI/SignIn";
        });
        var app = builder.Build();
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider
            (
            Path.Combine(Directory.GetCurrentDirectory(), "Content")
            ),
            RequestPath = "/Content"
        }
        );
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();

        app.Run();
        return 0;
    }
}