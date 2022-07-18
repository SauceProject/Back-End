
using System.Text;
using ITI.Sauce.Models;
using ITI.Sauce.MVC.Helpers;
using ITI.Sauce.Repository;
using ITI.Sauce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

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
        builder.Services.AddAuthentication(options =>
        {

            options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme=JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateAudience=false,
                ValidateIssuer=false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]))
            };
        });
        builder.Services.AddIdentity<Users, IdentityRole>().
            AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();
        builder.Services.AddScoped(typeof(VendorRepository));
        builder.Services.AddScoped(typeof(UserRepository));
        builder.Services.AddScoped(typeof(RestaurantRepository));
        builder.Services.AddScoped(typeof(RecipeRepository));
        builder.Services.AddScoped(typeof(RatingRepository));
        builder.Services.AddScoped(typeof(EmailServices));
        builder.Services.AddScoped(typeof(OrderRepository));
        builder.Services.AddScoped(typeof(CartRepository));
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
        builder.Services.AddScoped(typeof(FavRepository));
        builder.Services.AddScoped(typeof(EmailServices));
        builder.Services.Configure<SMTPConfig>(builder.Configuration.GetSection("SMTPConfig"));
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
        builder.Services.ConfigureApplicationCookie(Option =>
        {
            Option.LoginPath = "/Users/SignUp";
        });
        builder.Services.ConfigureApplicationCookie(Option =>
        {
            Option.LoginPath = "/UserAPI/SignIn";
         
           // Option.SignIn.RequireConfirmedEmail = true;

        });
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(i =>
            {
                i.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
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
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();

        app.Run();
        return 0;
    }
}