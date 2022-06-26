
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