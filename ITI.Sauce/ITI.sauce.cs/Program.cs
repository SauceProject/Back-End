
using ITI.Sauce.Models;
using ITI.Sauce.Repositorie;
using ITI.Sauce.Repositories;
using ITI.Sauce.Repository;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ITI.Sauce.Repositorie;
using ITI.Sauce.Repository;
using ITI.Sauce.ViewModels;
using ITI.Sauce.Models;


public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddScoped(typeof(CategoryRepository));
        builder.Services.AddScoped(typeof(IngredientRepository));


        builder.Services.AddScoped(typeof(UnitOfWork));
        builder.Services.AddScoped(typeof(DBContext));
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped(typeof(VendorRepository));
        builder.Services.AddScoped(typeof(UserRepository));
        builder.Services.AddScoped(typeof(RestaurantRepository));
        builder.Services.AddScoped(typeof(RecipeRepository));
        builder.Services.AddScoped(typeof(RatingRepository));
        builder.Services.AddScoped(typeof(OrderRepository));
        builder.Services.AddScoped(typeof(OrderListRepository));
        builder.Services.AddScoped(typeof(IngredientRepository));
        builder.Services.AddScoped(typeof(CategoryRepository));
        builder.Services.AddScoped(typeof(DBContext));
        builder.Services.AddScoped(typeof(UnitOfWork));
        var app = builder.Build();
        app.UseStaticFiles(new StaticFileOptions() 
        { 
            FileProvider= new PhysicalFileProvider
            ( 
            Path.Combine(Directory.GetCurrentDirectory(),"Content")
            ),
            RequestPath = "/Content"
        }
        );
        app.MapDefaultControllerRoute();
        app.Run();
        return 0;
    }
}